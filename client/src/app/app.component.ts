import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Shopper} from "./_models/shopper";
import {ShopperService} from "./_services/shopper.service";
import {ItemService} from "./_services/item.service";
import {ShoppingListService} from "./_services/shopping-list.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor() {
  }

  ngOnInit() {
  }
}
