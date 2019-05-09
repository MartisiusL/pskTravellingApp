import { Component, OnInit, ViewChild } from '@angular/core';
import {Trip} from '../trip';

@Component({
  selector: 'app-enter-travel-info',
  templateUrl: './enter-travel-info.component.html',
  styleUrls: ['./enter-travel-info.component.css']
})
export class EnterTravelInfoComponent implements OnInit {
	
  date = new Date();
  
  tripInfo = new Trip();
  locations = 
  [
	"an array",
	"that can be",
	"edited in TypeScript",
	"before the DOM is",
	"generated"
  
  ]
  
  @ViewChild('files') filesContainer: Object;
  @ViewChild('fileInput') fileInput: Object;
  
  
  constructor() {
  }
  

  ngOnInit() {
	  this.locations.push("like this");
  }
  
  ngAfterViewInit(){
	  console.log(this.tripInfo);
  }
  
  onUploadTicket(event){
	  alert("Doing stuff with file (AKA nothing yet, you can TypeScript here)");
	  console.log(this.fileInput);
	  if(event.target.files && event.target.files.length > 0) {
		  let file = event.target.files[0];
		  //this.fileInput.nativeElement.value = null;
		  //this.filesContainer.nativeElement.innerHTML += file.name + "<br>"
	  }
	  
  }
  
  onClickMe() {
    console.log(this.tripInfo);
  }
  

}
