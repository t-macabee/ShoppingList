import {Component, Inject, OnInit} from '@angular/core';
import {ShoppingListService} from "../_services/shopping-list.service";
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from "@angular/material/dialog";
import {Shopper} from "../_models/shopper";
import {ItemListComponent} from "../item-list/item-list.component";
import {ToastrService} from "ngx-toastr";
import {Item} from "../_models/item";

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent implements OnInit{
  shopper: Shopper;

  constructor(private shoppingListService: ShoppingListService,
              private dialogRef: MatDialogRef<ShoppingListComponent>,
              private dialog: MatDialog,
              private toastr: ToastrService,
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

}
