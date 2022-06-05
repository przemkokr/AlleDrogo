import { CategoryEnum } from "./category-enum";

export class AuctionItemModel {
  name: string;
  description: string;
  category: CategoryEnum;
  isNew: boolean;
}
