import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { ErrorHandler, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ErrorHandlerService } from "./error-handle-service";

@Injectable()
export class ErrorHandlerInterceptor implements HttpInterceptor {

  constructor(private error: ErrorHandlerService) { }

  public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return new Observable((observer) => {
      next.handle(req).subscribe(
        (res: HttpResponse<any>) => {
          if (res instanceof HttpResponse) {
            observer.next(res);
          }
        },
        (err: HttpErrorResponse) => {
          this.error.handleError(err);
        });
    });
  }
}
