import {Component, Inject, OnInit} from '@angular/core';
import {ShoppingList} from "../_models/shoppingList";
import {ItemService} from "../_services/item.service";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {Item} from "../_models/item";
import {ShoppingListService} from "../_services/shopping-list.service";

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit{
  shoppingList: ShoppingList;
  items: Item[] = [];

  constructor(private itemService: ItemService,
              private shoppingListService: ShoppingListService,
              private dialogRef: MatDialogRef<ItemListComponent>,
              @Inject(MAT_DIALOG_DATA) public data: {shoppingList: ShoppingList}
              )
  {
    this.shoppingList = data.shoppingList;
  }

  ngOnInit() {
    this.getItems();
  }

  getItems() {
    this.itemService.getItems().subscribe( response => {
      this.items = response;
    })
  }

  closeDialog() {
    this.dialogRef.close();
  }

  addItem(item: number) {
    this.shoppingListService.addItem(this.shoppingList.id, item).subscribe(response => {

    })
    this.dialogRef.close({ selected: item });
  }
}
