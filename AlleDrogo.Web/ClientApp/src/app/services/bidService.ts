import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { BidCommand } from "../models/bid-command";

@Injectable({
  providedIn: 'root'
})
export class BidService {
  httpClient: HttpClient = null;
  apiEndpoint: string = 'bid';
  apiUrl: string = null;

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    this.httpClient = http;
    this.apiUrl = this.getEndpointUrl(apiUrl);
  }

  private getEndpointUrl = (apiUrl: string) => {
    return apiUrl + this.apiEndpoint;
  }

  public bid(command: BidCommand): Observable<boolean> {
    const body = JSON.stringify(command);
    const headerOptions = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.httpClient.post<boolean>(this.apiUrl + '/bid', body, {
      headers: headerOptions
    }).pipe(catchError(this.handleError.bind(this)));
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
