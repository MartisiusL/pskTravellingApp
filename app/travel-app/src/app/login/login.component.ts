import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private Auth: AuthService, private router: Router) { }

  ngOnInit() {
  }

  register(): void {
    
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
        this.Auth.setLoggedIn(true)
        this.router.navigate(['home'])   
        console.log("successfully logged in")
      } else {
        window.alert(data.message)
      }
    })
  }

}
