import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ReactiveFormsModule } from '@angular/forms'

import { AppComponent } from './app.component';
import {router } from './app.route';
import { ListcomponentComponent } from './listcomponent/listcomponent.component';
import { ListdetailComponent } from './listcomponent/listdetail/listdetail.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import {HttpService} from './http.service'

@NgModule({
  declarations: [
    AppComponent,
    ListcomponentComponent,
    ListdetailComponent,
    RegistrationComponent,
    LoginComponent

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    router,ReactiveFormsModule
    
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
