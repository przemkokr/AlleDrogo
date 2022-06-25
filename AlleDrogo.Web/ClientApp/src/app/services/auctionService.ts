import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { AddAuctionCommand } from "../models/add-auction-command";
import { Auction } from "../models/auction-model";
import { GetByUserQuery } from "../models/get-by-user-query";

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

  public createAuction(command: AddAuctionCommand): Observable<number> {
    const body = JSON.stringify(command);
    const headerOptions = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.httpClient.post<number>(this.apiUrl + '/create', body, {
      headers: headerOptions
    }).pipe(catchError(this.handleError.bind(this)));
  }

  public getByUser(query: GetByUserQuery) {
    let params = new HttpParams();
    params = params.append('queryType', query.queryType.toString());
    params = params.append('username', query.username);

    return this.httpClient.get<Auction[]>(this.apiUrl + '/get-by-user', { params: params });
  }

  handleError(errorResponse: HttpErrorResponse) {
    if (errorResponse.error instanceof ErrorEvent) {
      console.error('Client Side Error :', errorResponse.error.message);
    } else {
      console.error('Server Side Error :', errorResponse);
    }

    return throwError('Odnotowaliśmy problem z usługą. Pracujemy nad rozwiązaniem. Spróbuj ponownie później.');
  }
}
