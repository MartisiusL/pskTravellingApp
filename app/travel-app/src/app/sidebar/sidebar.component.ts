import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {


  // An array, that is used to create the sidebar links
  links = [
	{ href: "travel", text:"Enter TravelInfo" },
	{ href: "travel", text:"a" },
	{ href: "travel", text:"b" },
	{ href: "travel", text:"c" },
	{ href: "travel", text:"d" },
  ]

  constructor() { }

  ngOnInit() {
  }

}
