import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
	
  isCollapsed = true;

  constructor(private auth: AuthService) { }

  ngOnInit() {
  }

  logoutUser() {
    this.auth.setLoggedIn(false)
    console.log("successfully logged out")
  }
}
