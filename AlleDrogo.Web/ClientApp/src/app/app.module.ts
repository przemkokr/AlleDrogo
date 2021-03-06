import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { Auctions } from './auctions/auctions.component';
import { AuctionDetail } from './auctions/auction-detail.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ErrorHandlerInterceptor } from './services/ErrorHandlerInterceptor/error-handler-interceptor';
import { AuctionCreate } from './auctions/auction-create.component';
import { AuctionSummary } from './summary/auction.summary.component';
import { UserAuctions } from './auctions/user-auctions.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    Auctions,
    AuctionDetail,
    AuctionCreate,
    AuctionSummary,
    UserAuctions
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'auction/:id', component: AuctionDetail, pathMatch: 'full' },
      { path: 'create', component: AuctionCreate, pathMatch: 'full' },
      { path: 'summary/:id', component: AuctionSummary, pathMatch: 'full' },
      { path: 'my-auctions', component: UserAuctions, pathMatch: 'full' }
      // { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
    ]),
    ToastrModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorHandlerInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
