import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {catchError, map, throwError} from "rxjs";
import {ToastrService} from "ngx-toastr";

@Injectable({
  providedIn: 'root'
})
export class ShoppingListService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private toastr: ToastrService) { }

  getListByShopper(id: number) {
    return this.http.get<any>(this.baseUrl + 'ShoppingList/listByShopper/' + id);
  }

  createList(shopperId: number, listName: string) {
    return this.http.post(this.baseUrl + 'ShoppingList/create-list/' + shopperId + '/' + listName, {});
  }

  removeList(shopperId: number, listId: number) {
    return this.http.delete(this.baseUrl + 'ShoppingList/remove-list/' + shopperId + '/' + listId);
  }

  addItem(listId: number, itemId: number) {
    return this.http.post<any>(this.baseUrl + 'ShoppingList/add-item/' + listId + '/' + itemId, {})
      .pipe(
        map(response => {
          if (response) {
            if (response.canAddItem) {
              this.toastr.success("Item added to the list");
              return response.shoppingList;
            } else {
              this.toastr.error("Failed to add item to the list. Item cannot be added to more than three shopping lists or is already in the list.");
              return null;
            }
          }
        }),
        catchError(error => {
          this.toastr.error("Failed to add item to the list", error.message || error);
          return throwError(error);
        })
      );
  }

  removeItem(listId: number, itemId: number) {
    return this.http.delete(this.baseUrl + 'ShoppingList/remove-item/' + listId + '/' + itemId);
  }
}
