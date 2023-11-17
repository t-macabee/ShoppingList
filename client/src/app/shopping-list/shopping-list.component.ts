import {Component, Inject, OnInit} from '@angular/core';
import {ShoppingListService} from "../_services/shopping-list.service";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {Shopper} from "../_models/shopper";

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent implements OnInit{
  shopper: Shopper;

  constructor(private shoppingListService: ShoppingListService,
              @Inject(MAT_DIALOG_DATA) public data: { shopper: Shopper})
  {
    this.shopper = data.shopper;
    this.loadShoppingList();
  }

  ngOnInit() {
  }

  loadShoppingList() {
    const shopperId = this.shopper.id;
    this.shoppingListService.getListForShopper(shopperId).subscribe(response => {
      this.shopper.shoppingList = response;
    }, error => {
      console.log(error);
    })
  }
}
