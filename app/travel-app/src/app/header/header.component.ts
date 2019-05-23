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
  authServ: AuthService

  setIsAdmin(value: boolean) {
    this.isAdmin = value
  }

  constructor(private auth: AuthService, router: Router) {
    this.authServ = auth
    }
  ngOnInit() {
  }
  ngDoCheck(): void {
    this.isAdmin = this.authServ.IsAdmin
  }

  logoutUser() {
    this.auth.setLoggedIn(false)
    this.setIsAdmin(false)
    console.log("successfully logged out")
  }
}
