import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { UserService } from '../user.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  currentUserName: string

  /* @Task its an easy task, but someone please make a clean and nice homepage, add instructions how to
  use it, maybe some icons, clean text, even credits of who created this web can be added, its freedom
  of what to do here, but this page shouldnt remain blank and even the small design adds confidence
  for the final product, so make it look good.*/
  constructor(private userService: UserService,
    private ref: ChangeDetectorRef,
    private route: ActivatedRoute, 
    private authService: AuthService ) { }

  ngOnInit() {
    this.userService.getUserName(this.authService.getCurrentUserId()).subscribe(data =>
      {
        this.currentUserName = data.toString()
        this.ref.detectChanges()
      })
  }

}
