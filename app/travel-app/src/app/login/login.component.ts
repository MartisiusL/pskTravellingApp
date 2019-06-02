import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import {ViewEncapsulation, OnDestroy} from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class LoginComponent implements OnInit, OnDestroy {

  constructor(private Auth: AuthService, private router: Router) { }

  ngOnInit() {
	  document.body.className = "OtherBackground";
  }

  register(): void {
    
  }
  
  ngOnDestroy(){
	   document.body.className = "";
  }

  loginUser(event) {
    event.preventDefault
    const target = event.target
    const username = target.querySelector('#username').value
    const password = target.querySelector('#password').value
    
    this.Auth.getUserDetails(username, password).subscribe(data => {
      if(data.success) {
        if(data.admin) {
          this.Auth.setIsAdmin(true)
        }
		if(data.organizer) {
          this.Auth.setIsOrganizer(true)
        }
        this.Auth.setLoggedIn(true)
        this.Auth.setCurrentUserId(data.userId)
        this.router.navigate(['home'])   
        console.log("successfully logged in")
      } else {
        window.alert(data.message)
      }
    })
  }

}
