import { VideoplayerComponent } from './videoplayer/videoplayer.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FavouriteComponent } from './favourite/favourite.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
//import { RegistrationComponent } from './registration/registration.component';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component'
import {ForgetPasswordComponent} from './forget-password/forget-password.component'
const routes: Routes = [
  {path:"",component:LoginComponent},
  //{path:"registration",component:RegistrationComponent},
  {path:"login",component:LoginComponent},
  {path:"reset-password",component: ResetPasswordComponent},
  {path:"forget-password",component: ForgetPasswordComponent},
  {path:"home",component:HomeComponent},
  {path:"userprofile",component:UserprofileComponent},
  {path:"fav",component:FavouriteComponent},
  {path:"videoplayer",component:VideoplayerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
