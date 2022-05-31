import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Auction } from "../models/auction-model";

@Injectable({
  providedIn: 'root'
})
export class AuctionService {
  httpClient: HttpClient = null;  
  apiEndpoint: string = 'auction';
  apiUrl: string = null;

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    this.httpClient = http;
    this.apiUrl = this.getEndpointUrl(apiUrl);
  }

  private getEndpointUrl = (apiUrl: string) => {
    return apiUrl + this.apiEndpoint;
  }

  public getAuctions() {
    return this.httpClient.get<Auction[]>(this.apiUrl + '/get-all');
  }

  public getAuction(id: number) {
    return this.httpClient.get<Auction>(this.apiUrl + '/get-by-id/' + id);
  }
}
