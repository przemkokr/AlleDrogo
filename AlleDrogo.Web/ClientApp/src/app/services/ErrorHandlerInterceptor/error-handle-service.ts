import { HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ToastrService } from "ngx-toastr";

@Injectable({
  providedIn: "root",
})
export class ErrorHandlerService {

  constructor(private toastr: ToastrService) { }

  public handleError(err: HttpErrorResponse) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occured: ${err.error.message}`;
    } else {
      switch (err.status) {
        case 400:
          errorMessage = this.handleBackendValidation(err);
          break;
        case 401:
          errorMessage = `${err.status}: Unauthorized`;
          break;
        case 403:
          errorMessage = `${err.status}: Forbidden`;
          break;
        case 404:
          errorMessage = `${err.status}: Requested resource do not exists`;
          break;
        case 412:
          errorMessage = `${err.status}: Precondition failed`;
          break;
        case 500:
          errorMessage = this.handleBackendValidation(err);
          break;
        case 503:
          errorMessage = `${err.status}: The requested service is not available`;
          break;
        default:
          errorMessage = `${err.status}: Something went wrong`;
          break;
      }
    }
    this.toastr.error(errorMessage);
  }

  private handleBackendValidation(error: HttpErrorResponse) : string {
    const message = error.error as string;
    let msgArr = message.split(':');
    const finalMsg = msgArr[1].split('\n')[0];
    return finalMsg;
  }
}
