import { Component, OnInit } from '@angular/core';
import { Identifiers } from '@angular/compiler';
import { UserService } from '../user.service';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { OfficeService, Office } from '../office.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userInfo = {}
  offices = []

  constructor(private userService: UserService, private auth: AuthService, private router: Router, private officeService: OfficeService) {
		this.officeService.getOffices().subscribe(offices => {this.offices = offices});
  }

  
  
  onRegisterClick() {
    this.userService.getUserDetails(this.userInfo);
  }

  ngOnInit() {
    document.body.className = "OtherBackground";
  }

}

export interface NewUser{
	Username: string;
	Password: string;
	Name: string;
  Surname: string;
  Phone: string;
  office: number;
  IsAdmin: boolean;
  IsOrganizer: boolean;
}