import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Shopper} from "../_models/shopper";

@Injectable({
  providedIn: 'root'
})
export class ShopperService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getShoppers() {
    return this.http.get<Shopper[]>(this.baseUrl + 'Shopper');
  }
}
