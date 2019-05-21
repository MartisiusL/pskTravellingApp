import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
//import { AuthService } from '../auth.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  constructor(/*private Auth: AuthService,*/ private router: Router, private http: HttpClient) { }

  public retPostData;
  public retGetData;

  ngOnInit() {
  }

  public PostData() {
    const url ="http://localhost:49528/api/Home";
    const retVal = this.http.post(url, {FstVarValue: '111', SndVarValue: '222'}).subscribe
    (data => {this.retPostData = data;
    });  
  }

  public GetData() {
    const url ="http://localhost:49528/api/Home/5";
    this.http.get(url).subscribe(data => {this.retGetData = data;});
  }

  public PutData() {
    const url="http://localhost:49528/api/Home/10";
    this.http.put(url, {DataVar1:'val1', DataVar2:'val2'})
    .subscribe(data => console.log(data));
  }

  public DeleteData() {
    const url ="http://localhost:49528/api/Home/5";
    this.http.delete(url).subscribe(data=> console.log(data),err=>{console.log("Error Occured")});
  }

  loginUser(event) {
    event.preventDefault()
    const target = event.target
    const username = target.querySelector('#username').value
    const password = target.querySelector('#password').value

    // this.Auth.getUserDetails(username, password).subscribe(data => {
    //   if(data.success) {
    //     this.router.navigate(['trips'])
    //     this.Auth.setLoggedIn(true);
    //   } else {
    //     window.alert(data)
    //   }
    // })
    console.log(username, password)
  }

}
