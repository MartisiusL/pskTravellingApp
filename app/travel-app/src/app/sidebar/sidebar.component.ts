import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {


  // An array, that is used to create the sidebar links
  links = [
	{ href: "trips", text:"Trip List" },
	{ href: "travel", text:"Enter Trip Info Component" },
	{ href: "register", text:"Register" },
  ]

  constructor() { }

  ngOnInit() {
  }

}
