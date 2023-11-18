import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get<any>(this.baseUrl + 'Item');
  }

  getItem(id: number) {
    return this.http.get(this.baseUrl + 'Item/' + id);
  }
}
