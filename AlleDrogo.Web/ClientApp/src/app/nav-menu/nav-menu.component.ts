import { Component, Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthorizeService } from '../../api-authorization/authorize.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})

@Injectable()
export class NavMenuComponent implements OnInit {

  constructor(private authorizeService: AuthorizeService) { }

  isExpanded = false;
  public isAuthenticated: Observable<boolean>;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ngOnInit(): void {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
  }  
}
