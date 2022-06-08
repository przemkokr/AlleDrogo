import { Component, Inject, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Auction } from '../models/auction-model';
import { AuctionService } from '../services/auctionService';

@Component({
  selector: 'auction.summary',
  templateUrl: './auction.summary.component.html'
})

export class AuctionSummary implements OnInit {
  auction: Auction = null;
  id: number;
  private sub: any;

  constructor(
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private readonly auctionService: AuctionService) {

  }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];

      this.auctionService.getAuction(this.id).subscribe(auction => {
        this.auction = auction;
      }, error => {
        console.log('Something went wrong.');
      });
    });
  };
}
