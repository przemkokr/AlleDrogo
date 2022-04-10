import { Item } from "./item-model";

export interface Auction {
  title: string;
  item: Item;
  startDate: Date;
  endDate: Date;
  description: string;
  currentValue: number;
  isBuyNow: boolean;
  buyNowValue: boolean;
}
