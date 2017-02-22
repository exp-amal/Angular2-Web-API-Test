import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from "@angular/forms";
import { Http } from '@angular/http'
import { HttpService } from '../http.service';
import { Router } from '@angular/router'

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  // Data Driven Signup form

  myForm: FormGroup;
  constructor(private service: HttpService,private router: Router) {
    this.myForm = new FormGroup({
      'firstName': new FormControl(),
      'lastName': new FormControl(),
      'dob': new FormControl(),
      'email': new FormControl(),
      'username': new FormControl(),
      'password': new FormControl()

    });
  }

  // On registration form submission
  
  onSubmit() {
    this.service.SaveData(this.myForm.value).subscribe(data => console.log(data));
    alert("Succesfully Registered");
              this.router.navigate(['./login']);

  }
}
