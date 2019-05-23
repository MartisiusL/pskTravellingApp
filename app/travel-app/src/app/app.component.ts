import { Component } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { AuthService } from './auth.service';
import { HeaderComponent } from './header/header.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Travel-app'
  showMenu: boolean = false
  constructor(router:Router, auth: AuthService, header: HeaderComponent) {
    router.events.forEach((event) => {
        if(event instanceof NavigationStart) {
            header.setIsAdmin(auth.IsAdmin)
            this.showMenu = auth.isLoggedIn         
        }
      });
    }
}
