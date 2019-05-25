import { Component, OnInit } from '@angular/core';
import { Identifiers } from '@angular/compiler';
import { UserService } from '../user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userInfo = {}

  constructor(private userService: UserService) { }

  onResgisterClick() {
    this.userService.getUserDetails(this.userInfo).subscribe(data => {
      alert(data)
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