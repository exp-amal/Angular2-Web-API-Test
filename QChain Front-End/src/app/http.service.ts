import { Headers, Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HttpService {

    username: any;
    constructor(private http: Http) { }

// service to be executed on user registration
    SaveData(myForm: any) {
        console.log(myForm);
        return this.http.post("http://localhost:11682/Registration", myForm).map((response: Response) => response);
    }

    // service to be executed on login form submission-login check
    LoginCheck(myForm: any) {
        return this.http.post("http://localhost:11682/Login", myForm).map((response: Response) => response.json());
    }

    //service to be executed on question submission
    SaveQuestion(myForm: any): Observable<any> {
        return this.http.post("http://localhost:11682/SubmitQuestion", myForm).map((response: Response) => response);
    }

    // service to be executed to get the questions from database
    GetQuestions(): Observable<any> {
        return this.http.get("http://localhost:11682/GetQuestions").map((response: Response) => response.json());
    }

    // service to be executed on answer submission
    SaveAnswer(myForm): Observable<any> {
        return this.http.post("http://localhost:11682/SubmitAnswer", myForm).map((response: Response) => response);
    }

    // service to be executed to get the question details
    GetQuestionsDetails(id): Observable<any> {
        return this.http.get("http://localhost:11682/GetQuestionDetails/" + id).map((response: Response) => response.json());
    }

    // service to get username
    GetUserName(myForm) {
        this.username = myForm.username;
    }
    
    // service to return username
    PostUserName() {
        return this.username;
    }

}
