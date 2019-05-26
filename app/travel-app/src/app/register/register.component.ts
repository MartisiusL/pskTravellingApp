import { Component, OnInit } from '@angular/core';
import { Identifiers } from '@angular/compiler';
import { UserService } from '../user.service';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userInfo = {}

  constructor(private userService: UserService, private auth: AuthService, private router: Router) { }

  onResgisterClick() {
    this.userService.getUserDetails(this.userInfo).subscribe(data => {
      if(data.success) {
        this.auth.setCurrentUserId(data.userId)
        this.router.navigate(['home']) 
      }
      else {
        alert("Operation was not successful! Please try again.")
      }
    })
  }

  ngOnInit() {
  }

}

export interface NewUser{
	Username: string;
	Password: string;
	Name: string;
  Surname: string;
  Phone: string;
}