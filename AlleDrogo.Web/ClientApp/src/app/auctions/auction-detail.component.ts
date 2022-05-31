import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Auction } from "../models/auction-model";
import { AuctionService } from "../services/auctionService";

@Component({
  selector: "auction-details",
  templateUrl: "auction-details.component.html"
})

export class AuctionDetail {
  auction: Auction = null;
  id: number;


  constructor(private readonly auctionService: AuctionService, private route: ActivatedRoute) { }


  ngOnInit() {
    //this.auctionService.getAuction()
  }
}
