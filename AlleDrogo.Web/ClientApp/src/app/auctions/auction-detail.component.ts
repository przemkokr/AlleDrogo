import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Auction } from "../models/auction-model";
import { AuctionService } from "../services/auctionService";

@Component({
  selector: 'auction-detail',
  templateUrl: './auction-detail.component.html'
})

export class AuctionDetail {
  auction: Auction = null;
  id: number;
  private sub: any;

  constructor(private readonly auctionService: AuctionService, private route: ActivatedRoute) { }


  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
    });

    this.auctionService.getAuction(this.id).subscribe(auction => {
      this.auction = auction;
    }, error => {
      console.log('Something went wrong.');
    })
  }
}
