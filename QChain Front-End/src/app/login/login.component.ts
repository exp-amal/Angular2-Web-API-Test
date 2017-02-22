import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from "@angular/forms";
import { HttpService } from '../http.service';
import { Router } from '@angular/router'


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  // Data driven login form

  myForm: FormGroup;
  constructor(private service: HttpService, private router: Router) {
    this.myForm = new FormGroup({

      'username': new FormControl(),
      'password': new FormControl()

    });
  }

  // method to be executed on login form submission

  onLogin() {
    this.service.LoginCheck(this.myForm.value)
      .subscribe((data) => {
        console.log(data);
        if (data == 1) {
          this.router.navigate(['./listcomponent']);
        }
        else {
          alert("Invalid Credentials Entered");
        }
      }
      );
      
    this.service.GetUserName(this.myForm.value);
  }
}


