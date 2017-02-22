import { Component, OnDestroy } from '@angular/core';
import { Myquestion } from "../../myquestion"
import { QuestionarrayService } from "../../questionarray.service";
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from "rxjs/Rx"
import { HttpService } from '../../http.service';
import { FormGroup, FormControl } from "@angular/forms";

@Component({
  selector: 'app-listdetail',
  templateUrl: './listdetail.component.html',
  styleUrls: ['./listdetail.component.css']
})
export class ListdetailComponent {

  questiondetails: any; //variables to store questiondetails
  id: any;
  private subscription: Subscription;

  myForm: FormGroup;
  constructor(private service: HttpService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.myForm = new FormGroup({
      'Answer': new FormControl(),
      'id': new FormControl()
    });
  }

  // method to be executed on submitting answer
  onAnswerSubmit() {

    this.myForm.value.id = this.id;
    this.service.SaveAnswer(this.myForm.value)
      .subscribe((data) => {
        this.UpdateAnswers();
      }
      );
  }

  // method to be executed for updating answer list
  UpdateAnswers() {
    this.service.GetQuestionsDetails(this.id)
      .subscribe((data) => {
        this.questiondetails = data;
      }
      );
  }

  ngOnInit() {
    // getting id from url
    this.subscription = this.activatedRoute.params.subscribe(
      (param: any) => {
        this.id = param['id'];
      }
    );
    // fetching question details
    this.service.GetQuestionsDetails(this.id).subscribe((data) => {
      this.questiondetails = data;
    }
    );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}


