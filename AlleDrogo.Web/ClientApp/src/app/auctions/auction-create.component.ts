import { Component, Injectable, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { AuthorizeService } from "../../api-authorization/authorize.service";
import { AddAuctionCommand } from "../models/add-auction-command";
import { AuctionService } from "../services/auctionService";


@Component({
  selector: 'auction-create',
  templateUrl: './auction-create.component.html'
})

@Injectable()
export class AuctionCreate implements OnInit {

  constructor(
    private readonly auctionService: AuctionService,
    private router: Router,
    private authorizeService: AuthorizeService,
    private toastr: ToastrService) { }

  public isBuyNow: boolean = false;
  public auctionTitle: string = "";
  public auctionDescription: string = "";
  public initialValue: number = 0;
  public buyNowValue: number = 0;
  public endDate: Date = null;
  public itemName: string = "";
  public itemDescription: string = "";
  public isItemNew: boolean = false;

  public isAuthenticated: Observable<boolean>;
  public userName: Observable<string>;
  public loggedUser: string = null;
  public createdAuctionId: number = 0;

  auctionTypes = [
    { id: 1, name: "Samochody" },
    { id: 2, name: "Moda" },
    { id: 3, name: "Elektronika" },
    { id: 4, name: "Dom i ogród" },
    { id: 5, name: "Usługi" },
    { id: 6, name: "Gry" },
    { id: 7, name: "Medykamenty" },
    { id: 8, name: "Kultura i sztuka" },
    { id: 9, name: "Uroda" },
    { id: 10, name: "Łapówki dla profesora :)" }
  ];

  selectedAuctionType: number = null;
    
  isAddingItem: boolean = false;
  needToCheckInputs: boolean = false;

  public onIsBuyNowChanged(value: boolean) {
    this.isBuyNow = value;
  }
  
  public onTitleChanged(value: string) {
    this.auctionTitle = value;
  }

  public onAuctionDescriptionChanged(value: string) {
    this.auctionDescription = value;
  }

  public onInitialValueChanged(value: number) {
    this.initialValue = value;
  }

  public onBuyNowChanged(value: number) {
    this.buyNowValue = value;
  }

  public onEndDateChanged(value: Date) {
    this.endDate = value;
  }

  public onItemNameChanged(value: string) {
    this.itemName = value;
  }

  public onItemDescriptionChanged(value: string) {
    this.itemDescription = value;
  }

  public onIsItemNewChanged(value: boolean) {
    this.isItemNew = value;
  }

  public isDateValid = (): boolean => {
    let endDate = new Date(this.endDate);
    let now = new Date();
    let result = this.endDate != null && endDate > now;
    return result;
  }


  public addItem = () => {
    if (this.canAddItem() == true) {
      this.isAddingItem = true;
      this.needToCheckInputs = false;
    } else {
      this.needToCheckInputs = true;
    }
  }

  public addAuction() {
    let canAdd = this.canAddAuction();

    if (canAdd) {
      let command = new AddAuctionCommand();
      command.userName = this.loggedUser;
      command.title = this.auctionTitle;
      command.description = this.auctionDescription;
      command.isBuyNow = this.isBuyNow;
      command.buyNowValue = this.buyNowValue;
      command.initialValue = this.initialValue;
      command.endDate = this.endDate;
      command.item.name = this.itemName;
      command.item.description = this.itemDescription;
      command.item.isNew = this.isItemNew;
      command.item.category = this.selectedAuctionType;

      this.auctionService.createAuction(command).subscribe(auctionId => {
        this.toastr.success("Pomyślnie dodano nową aukcję. Za chwilę zostaniesz do niej przekierowany.")
        this.createdAuctionId = auctionId;
        setTimeout(() => {
          var url = "/auction/" + this.createdAuctionId;
          this.router.navigateByUrl(url);
        }, 3000);
      }, (error) => {
        alert("Error" + error)
      }
      );
    }
  }

  canAddAuction = () => {
    return this.canAddItem() == true && this.isItemValid() == true;
  }

  isItemValid = () => {
    return this.itemName.length > 0 &&
      this.itemDescription.length > 0 &&
      this.selectedAuctionType != null;
  }

  public canAddItem = () : boolean => {
    return this.auctionTitle.length > 0 &&
      this.auctionDescription.length > 0 &&
      this.initialValue > 0 &&
      this.isDateValid();
  }

  ngOnInit(): void {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.userName.subscribe(name => {
      this.loggedUser = name;
    })
  }

}
