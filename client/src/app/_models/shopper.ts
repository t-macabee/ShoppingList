import {ShoppingList} from "./shoppingList";

export interface Shopper {
  id: number;
  shopperName: string;
  shoppingList: ShoppingList;
}
