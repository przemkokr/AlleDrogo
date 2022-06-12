import { Component, Inject } from '@angular/core';
import { Auction } from '../models/auction-model';
import { AuctionService } from '../services/auctionService';

@Component({
  selector: 'auctions',
  templateUrl: './auctions.component.html'
})

export class Auctions {
  auctions: Auction[] = [];
  filteredAuctions: Auction[] = [];
  allItems: number = null;

  constructor(private readonly auctionService: AuctionService) { }

  valueDown: number = 0;
  valueUp: number = 0;
  searchTerm: string = "";

  search = () => {
    let filtered = this.auctions;

    if (this.selectedAuctionType && this.selectedAuctionType > -1) {
      filtered = filtered.filter(a => a.item.category == this.selectedAuctionType.toString());
    }

    if (this.searchTerm && this.searchTerm.length) {
      filtered = filtered.filter(a => a.title.toLowerCase().includes(this.searchTerm));
    }

    if (this.valueDown && this.valueDown != 0) {
      filtered = filtered.filter(a => a.currentValue > this.valueDown);
    }

    if (this.valueUp && this.valueUp != 0) {
      filtered = filtered.filter(a => a.currentValue < this.valueUp);
    }

    this.filteredAuctions = filtered;
  }

  auctionTypes = [
    { id: -1, name: "Wszystkie" },
    { id: 0, name: "Samochody" },
    { id: 1, name: "Moda" },
    { id: 2, name: "Elektronika" },
    { id: 3, name: "Dom i ogród" },
    { id: 4, name: "Usługi" },
    { id: 5, name: "Gry" },
    { id: 6, name: "Medykamenty" },
    { id: 7, name: "Kultura i sztuka" },
    { id: 8, name: "Uroda" }
  ];

  selectedAuctionType: number = null;

  ngOnInit() {
    this.auctionService.getAuctions().subscribe(auctions => {
      this.auctions = auctions;
      this.filteredAuctions = auctions;
      this.allItems = auctions.length;
    }, error => {
      console.log('Something went wrong.');
    })
  }
}


