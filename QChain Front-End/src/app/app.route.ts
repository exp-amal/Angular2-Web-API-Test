import {Routes,RouterModule} from "@angular/router";
import {ListdetailComponent}from "./listcomponent/listdetail/listdetail.component";
import{ListcomponentComponent}from'./listcomponent/listcomponent.component';
import{DETAILROUTES} from'./listcomponent/listcomponent.route1';
import {RegistrationComponent} from "./registration/registration.component"
import {LoginComponent} from "./login/login.component"
const APPROUTES:Routes=[
{path:'registration',component:RegistrationComponent},
{path:'login',component:LoginComponent},
{path:'listquestions',component:ListcomponentComponent},
{path:'listdetailcomponent/:id',component:ListdetailComponent},
{path:'listcomponent',component:ListcomponentComponent,children:DETAILROUTES}];
export const router=RouterModule.forRoot(APPROUTES);
