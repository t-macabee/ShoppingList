import { Component } from '@angular/core';
import {Shopper} from "../_models/shopper";
import {ShopperService} from "../_services/shopper.service";
import {ToastrService} from "ngx-toastr";
import {MatDialog} from "@angular/material/dialog";
import {ShoppingListComponent} from "../shopping-list/shopping-list.component";
import {ShoppingListService} from "../_services/shopping-list.service";
import {ShoppingList} from "../_models/shoppingList";

@Component({
  selector: 'app-shopper',
  templateUrl: './shopper.component.html',
  styleUrls: ['./shopper.component.css']
})
export class ShopperComponent {
  shoppers: Shopper[] = [];

  constructor(private shopperService: ShopperService,
              private shoppingListService: ShoppingListService,
              private toastr: ToastrService,
              private dialog: MatDialog) { }

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

  openForm(shopper: Shopper) {
    if (!shopper.shoppingList) {
      this.createList(shopper);
    } else {
      this.openList(shopper);
    }
  }

  openList(shopper: Shopper) {
    const dialogRef = this.dialog.open(ShoppingListComponent, {
      height: '500px',
      width: '500px',
      disableClose: true,
      data: { shopper: shopper }
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed', result);
    });
  }

  createList(shopper: Shopper) {
    const createList = confirm('Shopper doesn\'t have a shopping list. Do you want to create one?');

    if(createList) {
      const listName = `${shopper.shopperName}'s List`;
      this.shoppingListService.createList(shopper.id, listName).subscribe(
        (response: ShoppingList) => {
          shopper.shoppingList = response;
          this.openList(shopper);
        },
        (error) => {
          console.error('Error creating shopping list', error);
        }
      );
    }
  }

  deleteList(shopper: Shopper) {
    if (!shopper.shoppingList) {
      this.toastr.warning('Shopping list is already removed.');
      return;
    }
    const listId = shopper.shoppingList.id;

    this.shoppingListService.removeList(shopper.id, listId).subscribe(
      () => {
        this.toastr.success('Shopping list removed successfully!');
        shopper.shoppingList = null;
      },
      (error) => {
        this.toastr.error('Error removing shopping list.');
        console.error('Error deleting shopping list', error);
      }
    );
  }
}
