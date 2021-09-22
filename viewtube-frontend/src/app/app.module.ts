import { SharedService } from './Services/shared.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
//import { RegistrationComponent } from './registration/registration.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { FavouriteComponent } from './favourite/favourite.component';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { VideoSectionComponent } from './video-section/video-section.component';
import { YouTubePlayerModule } from "@angular/youtube-player";
import { VideoplayerComponent } from './videoplayer/videoplayer.component';
import { FavButtonComponent } from './fav-button/fav-button.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';

@NgModule({
  declarations: [
    AppComponent,
    //RegistrationComponent,
    HomeComponent,
    LoginComponent,
    FavouriteComponent,
    UserprofileComponent,
    VideoSectionComponent,
    VideoplayerComponent,
    FavButtonComponent,
    SideBarComponent,
    ResetPasswordComponent,
    ForgetPasswordComponent
  
   
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    YouTubePlayerModule
    
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
