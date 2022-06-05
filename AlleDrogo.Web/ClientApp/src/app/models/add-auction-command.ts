import { AuctionItemModel } from "./auction-item-model";

export class AddAuctionCommand {
  constructor() {
    this.item = new AuctionItemModel();
  }

  item: AuctionItemModel;
  userName: string;
  title: string;
  endDate: Date;
  description: string;
  isBuyNow: boolean;
  buyNowValue: number = null;
  initialValue: number;
}
