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

  loginUser(event) {
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
