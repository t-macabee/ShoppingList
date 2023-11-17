import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ShoppingListService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAllLists() {
    return this.http.get(this.baseUrl + 'ShoppingList');
  }

  getList(id: number) {
    return this.http.get(this.baseUrl + 'ShoppingList/' + id);
  }

  getListForShopper(id: number) {
    return this.http.get(this.baseUrl + 'ShoppingList/listByShopper/' + id);
  }

  createList(shopperId: number, listName: string) {
    return this.http.post(this.baseUrl + 'ShoppingList/create-list/' + shopperId + '/' + listName, {});
  }

  removeList(shopperId: number, listId: number) {
    return this.http.delete(this.baseUrl + 'ShoppingList/remove-list/' + shopperId + '/' + listId);
  }

  addItem(listId: number, itemId: number) {
    return this.http.post(this.baseUrl + 'ShoppingList/add-item/' + listId + '/' + itemId, {});
  }

  removeItem(listId: number, itemId: number) {
    return this.http.delete(this.baseUrl + 'ShoppingList/remove-item/' + listId + '/' + itemId);
  }
}
