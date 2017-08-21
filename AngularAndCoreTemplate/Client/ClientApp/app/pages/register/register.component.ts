import { Component, OnInit } from '@angular/core';

import { AuthService } from './../../services/auth.service';

import { UserRegisterModel } from './../../models/user-register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  model: UserRegisterModel;

  constructor(private authService: AuthService) {
    this.model = new UserRegisterModel;
  }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model)
      .subscribe(result => {
        console.log(result);
      });
  }

}
