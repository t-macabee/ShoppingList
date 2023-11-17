import { Component } from '@angular/core';
import {Shopper} from "../_models/shopper";
import {ShopperService} from "../_services/shopper.service";
import {ItemService} from "../_services/item.service";
import {ShoppingListService} from "../_services/shopping-list.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-shopper',
  templateUrl: './shopper.component.html',
  styleUrls: ['./shopper.component.css']
})
export class ShopperComponent {
  shoppers: Shopper[] = [];

  constructor(private shopperService: ShopperService,
              private itemService: ItemService,
              private shoppingListService: ShoppingListService,
              private toastr: ToastrService) { }

  ngOnInit() {
    this.getShoppers();
  }

  getShoppers() {
    this.shopperService.getShoppers().subscribe(response => {
      this.shoppers = response;
    }, error => {
      this.toastr.error('Error fetching data', error);
    })
  }
}
