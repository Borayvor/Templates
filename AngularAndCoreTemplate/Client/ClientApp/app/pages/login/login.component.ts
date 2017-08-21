import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from './../../services/auth.service';

import { UserRegisterModel } from './../../models/user-register.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public model: UserRegisterModel;

  constructor(
    private authService: AuthService,
    private router: Router
  ) {
    this.model = new UserRegisterModel;
  }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model)
      .subscribe(result => {

        if (result.State === 1) {
          this.router.navigate(['']);
        } else {
          alert(result.Msg);
        }
      });
  }

}
