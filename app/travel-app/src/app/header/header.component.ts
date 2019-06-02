import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router, NavigationStart } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
	
  isCollapsed = true
  isAdmin: boolean = false
  isOrganizer: boolean = false
  authServ: AuthService

  setIsAdmin(value: boolean) {
    this.isAdmin = value
  }
  
  setIsOrganizer(value: boolean) {
    this.isOrganizer = value
  }

  constructor(private auth: AuthService, router: Router) {
    this.authServ = auth
    }
  ngOnInit() {
  }
  ngDoCheck(): void {
    this.isAdmin = this.authServ.IsAdmin
	this.isOrganizer = this.authServ.IsOrganizer
  }

  logoutUser() {
    this.auth.setLoggedIn(false)
    this.setIsAdmin(false)
	this.setIsOrganizer(false)
    this.auth.setCurrentUserId(-1)
    console.log("successfully logged out")
  }
}
