import { Component, Inject } from '@angular/core';
import { Auction } from '../models/auction-model';
import { AuctionService } from '../services/auctionService';

@Component({
  selector: "auctions",
  templateUrl: "auctions.component.html"
})

export class Auctions {
  auctions: Auction[] = [];
  allItems: number = null;

  constructor(private readonly auctionService: AuctionService) {

  }

  ngOnInit() {
    this.auctionService.getAuctions().subscribe(auctions => {
      this.auctions = auctions;
      this.allItems = auctions.length;
    }, error => {
      console.log('Something went wrong.');
    })
  }
}


