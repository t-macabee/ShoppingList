import {Component, Inject, OnInit} from '@angular/core';
import {ShoppingListService} from "../_services/shopping-list.service";
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from "@angular/material/dialog";
import {Shopper} from "../_models/shopper";
import {ItemListComponent} from "../item-list/item-list.component";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent {
  shopper: any;

  constructor(private shoppingListService: ShoppingListService,
              private dialogRef: MatDialogRef<ShoppingListComponent>,
              private dialog: MatDialog,
              private toastr: ToastrService,
              @Inject(MAT_DIALOG_DATA) public data: { shopper: Shopper})
  {
    this.shopper = data.shopper;
    this.loadShoppingList();
  }

  loadShoppingList() {
    const shopperId = this.shopper.id;
    this.shoppingListService.getListByShopper(shopperId).subscribe(response => {
      this.shopper.shoppingList = response;
      console.log('Shopper:', this.shopper);
    }, error => {
      console.log(error);
    })
  }

  closeDialog() {
    this.dialogRef.close();
  }

  itemList() {
    const dialogRef = this.dialog.open(ItemListComponent, {
      height: '370px',
      width: '300px',
      disableClose: true,
      data: { shoppingList: this.shopper.shoppingList }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result && result.selected) {
        const selectedItem = result.selected;
        this.loadShoppingList();
      }
    });
  }


  removeItem(itemId: number) {
      const listId = this.shopper.shoppingList.id;

      this.shoppingListService.removeItem(listId, itemId).subscribe(
        response => {
          if (response) {
            this.toastr.success("Item removed from the list");
            this.loadShoppingList();
          }
        },
        error => {
          this.toastr.error("Failed to remove item from the list", error.message || error);
        }
      );
    }
}
