import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { Auction } from '../models/auction-model';
import { GetByUserQuery } from '../models/get-by-user-query';
import { QueryType } from '../models/query-type';
import { AuctionService } from '../services/auctionService';

@Component({
  selector: 'user-auctions',
  templateUrl: './user-auctions.component.html'
})

export class UserAuctions implements OnInit {
  auctions: Auction[] = [];

  public isAuthenticated: Observable<boolean>;
  public userName: Observable<string>;
  public loggedUser: string = null;
  public selectedQueryType: QueryType;

  constructor(
    private readonly auctionService: AuctionService,
    private authorizeService: AuthorizeService) { }

  ngOnInit() {
    this.refresh();
  }

  getActive = () => {
    this.selectedQueryType = QueryType.ActiveByUser;
    this.auctionService.getByUser(new GetByUserQuery(this.selectedQueryType, this.loggedUser))
      .subscribe(auctions => {
        this.auctions = auctions;
      }, error => {
        console.log('Something went wrong.');
      });
  }

  getWon = () => {
    this.selectedQueryType = QueryType.WonByUser;
    this.auctionService.getByUser(new GetByUserQuery(this.selectedQueryType, this.loggedUser))
      .subscribe(auctions => {
        this.auctions = auctions;
      }, error => {
        console.log('Something went wrong.');
      });
  }

  refresh = () => {
    this.selectedQueryType = QueryType.ActiveByUser;

    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.userName.subscribe(name => {
      this.loggedUser = name;
    });

    this.auctionService.getByUser(new GetByUserQuery(this.selectedQueryType, this.loggedUser))
      .subscribe(auctions => {
        this.auctions = auctions;
      }, error => {
        console.log('Something went wrong.');
      });
  }
}
