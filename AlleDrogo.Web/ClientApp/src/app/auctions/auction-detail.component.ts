import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { AuthorizeService } from "../../api-authorization/authorize.service";
import { Auction } from "../models/auction-model";
import { AuctionService } from "../services/auctionService";

@Component({
  selector: 'auction-detail',
  templateUrl: './auction-detail.component.html'
})

export class AuctionDetail implements OnInit {
  auction: Auction = null;
  id: number;
  private sub: any;

  public isAuthenticated: Observable<boolean>;
  public userName: Observable<string>;
  public loggedUser: string = null;

  constructor(
    private readonly auctionService: AuctionService,
    private route: ActivatedRoute,
    private authorizeService: AuthorizeService) { }


  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];

      this.auctionService.getAuction(this.id).subscribe(auction => {
        this.auction = auction;
      }, error => {
        console.log('Something went wrong.');
      })

      this.isAuthenticated = this.authorizeService.isAuthenticated();
      this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
      this.userName.subscribe(name => {
        this.loggedUser = name;
      })
    });
  };
}
