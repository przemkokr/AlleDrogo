import { Component } from '@angular/core';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html'
})

export class LoginPage {
  userName: string = null;
  userPassword: string = null;
}
