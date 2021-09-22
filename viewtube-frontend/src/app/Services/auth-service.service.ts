import { LoginUser } from '../Models/loginUser';
import { RegisterUser } from '../Models/registerUser';
import {ResetPassword} from '../Models/resetPassword';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ForgetPassword } from '../Models/forgetPassword';


@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  

  constructor(private httpclient:HttpClient) { }

  emailIs : any = sessionStorage.getItem("email");
  //emailIs : any ;

  loginApiEndPoint : string = `http://localhost:5000/api/auth/login`;
  registerApiEndPoint : string = `http://localhost:5000/api/auth/register`;
  //userApiEndPoint : string = `http://localhost:5000/api/auth/user?email=${this.emailIs}`;
  userApiEndPoint2 : string = `http://localhost:5000/api/auth/user`;
  resetPasswordEndpoint : string = `http://localhost:5000/api/auth/reset-password`;
  forgetPasswordEndpoint : string = `http://localhost:5000/api/auth/forget-password`;

  public loginAuthenticate(user:LoginUser) 
  {
    let userdata= {"email":user.email, "password":user.password};
    this.emailIs = user.email;
    console.log(`User Details in service ${user}`);
    console.log(userdata);
    // this.httpclient.get(this.apiEndpoint,
    //   {headers:new HttpHeaders().set('Authorization',`Bearer ${sessionStorage.getItem('token')}`)})
    return this.httpclient.post(this.loginApiEndPoint,userdata);
  }
  public registerUser(user: RegisterUser) 
  {          
    let userdata= {"name": user.name,"email":user.email, "phonenumber": user.phonenumber,"address": user.address, "password":user.password};
    console.log(`User Details in regitration ${user}`);
    console.log(userdata);
    // this.httpclient.get(this.apiEndpoint,
    //   {headers:new HttpHeaders().set('Authorization',`Bearer ${sessionStorage.getItem('token')}`)})
    return this.httpclient.post(this.registerApiEndPoint,userdata,{responseType: 'text'});
  }
  public getUser(){
    //email = this.emailIs;
    //return this.httpclient.post(this.userApiEndPoint, this.emailIs);
    return this.httpclient.post(`${this.userApiEndPoint2}?email=${this.emailIs}`, this.emailIs);
  }

  public getUserForForgetPass(email : string){
    //email = this.emailIs;
    //return this.httpclient.post(this.userApiEndPoint, this.emailIs);
    return this.httpclient.post(`${this.userApiEndPoint2}?email=${email}`, this.emailIs);
  }

  public resetPassword(user : ResetPassword){
    let userdata= {"email":this.emailIs, "oldPassword":user.oldPassword, "newPassword":user.newPassword};
    return this.httpclient.post(this.resetPasswordEndpoint,userdata,{responseType: 'text'});
  }

  public forgetPassword(user : ForgetPassword){
    let userdata= {"email":user.email, "newPassword":user.newPassword};
    return this.httpclient.post(this.forgetPasswordEndpoint,userdata,{responseType: 'text'});
  }

}
