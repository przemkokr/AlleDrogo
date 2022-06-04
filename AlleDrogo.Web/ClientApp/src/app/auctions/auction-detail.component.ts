import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { AuthorizeService } from "../../api-authorization/authorize.service";
import { Auction } from "../models/auction-model";
import { BidCommand } from "../models/bid-command";
import { AuctionService } from "../services/auctionService";
import { BidService } from "../services/BidService";

@Component({
  selector: 'auction-detail',
  templateUrl: './auction-detail.component.html'
})

export class AuctionDetail implements OnInit {
  auction: Auction = null;
  id: number;
  private sub: any;
  isAddingBid: boolean = false;
  bidValue: number;

  public isAuthenticated: Observable<boolean>;
  public userName: Observable<string>;
  public loggedUser: string = null;

  constructor(
    private readonly auctionService: AuctionService,
    private readonly bidService: BidService,
    private route: ActivatedRoute,
    private authorizeService: AuthorizeService,
    private toastr: ToastrService) { }

  addBid = () => {
    this.isAddingBid = !this.isAddingBid;
  }

  bid = (value: string) => {
    let bidValue = +value;
    let command = new BidCommand;
    command.auctionId = this.id;
    command.username = this.loggedUser;
    command.biddingTime = new Date();
    command.bidAmount = bidValue;

    this.bidService.bid(command).subscribe((status) => {
      this.toastr.success("Zalicytowałeś!")
      this.refresh();
    }, (error) => {
      alert("Error" + error)}
    );
  }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];

      this.refresh();

      this.isAuthenticated = this.authorizeService.isAuthenticated();
      this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
      this.userName.subscribe(name => {
        this.loggedUser = name;
      })
    });
  };

  refresh = () => {
    this.auctionService.getAuction(this.id).subscribe(auction => {
      this.auction = auction;
    }, error => {
      console.log('Something went wrong.');
    })
  }
}
