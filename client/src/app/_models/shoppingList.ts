import {Item} from "./item";
import {Shopper} from "./shopper";

export interface ShoppingList {
  id: number;
  listName: string;
  shopperId: number;
  shopper: Shopper;
  items: Item[];
}
