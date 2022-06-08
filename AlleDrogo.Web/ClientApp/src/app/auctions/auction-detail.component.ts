import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { AuthorizeService } from "../../api-authorization/authorize.service";
import { Auction } from "../models/auction-model";
import { BidCommand } from "../models/bid-command";
import { BuyNowCommand } from "../models/buy-now-command";
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
  isDecisionMaking: boolean = false;

  public isAuthenticated: Observable<boolean>;
  public userName: Observable<string>;
  public loggedUser: string = null;

  constructor(
    private readonly auctionService: AuctionService,
    private readonly bidService: BidService,
    private route: ActivatedRoute,
    private authorizeService: AuthorizeService,
    private toastr: ToastrService,
    private router: Router  ) { }

  addBid = () => {
    this.isAddingBid = !this.isAddingBid;
  }

  bid = (value: string) => {
    let bidValue = +value;

    if (this.auction.isBuyNow && bidValue >= this.auction.buyNowValue) {
      this.isDecisionMaking = true;
      this.isAddingBid = false;
      return;
    }

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

  buyNow = () => {
    let command = new BuyNowCommand;
    command.auctionId = this.id;
    command.userName = this.loggedUser;

    this.bidService.buyNow(command).subscribe((auctionId) => {
      this.toastr.success("Kupiłeś przedmiot! Za chwilę zostaniesz przekierowany do podsumowania");
      setTimeout(() => {
        var url = "/summary/" + auctionId;
        this.router.navigateByUrl(url);
      }, 3000);
    }, (error) => {
      alert("Error" + error)
    }
    );
  }

  hideBuyNowPanel = () => {
    this.isDecisionMaking = false;
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
    this.isAddingBid = false;
  }
}
