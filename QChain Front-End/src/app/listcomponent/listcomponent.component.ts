import { Component, OnInit } from '@angular/core';
import { Myquestion } from "../myquestion"
import { QuestionarrayService } from "../questionarray.service";
import { FormGroup, FormControl } from "@angular/forms";
import { HttpService } from '../http.service';
import { Router } from '@angular/router'


@Component({
  selector: 'app-listcomponent',
  templateUrl: './listcomponent.component.html',
  styleUrls: ['./listcomponent.component.css'],

})
export class ListcomponentComponent {

  questiondetails: any;
  questionlist: any;
  // data driven Answer form

  myForm: FormGroup;
  constructor(private service: HttpService, private router: Router) {
    this.myForm = new FormGroup({
      'title': new FormControl(),
      'description': new FormControl(),
      'Owner': new FormControl()
    });
  }
  // method to be executed on clicking a particular question

  onClick(id) {
    this.router.navigate(['listdetailcomponent', id]);
  }

  // method to be executed on question 

  onQuestionSubmit() {

    var Owner = this.service.PostUserName();
    this.myForm.value.owner = Owner;
    this.service.SaveQuestion(this.myForm.value)
      .subscribe((data) => {
        this.UpdateQuestionList();
      }
      );
  }

  ngOnInit() {
    // updating questions list on component initialization
    this.UpdateQuestionList();
  }

  // method to be executed for updating questions list

  UpdateQuestionList() {
    this.service.GetQuestions()
      .subscribe((data) => {
        this.questionlist = data;
      }
      );
  }
}
