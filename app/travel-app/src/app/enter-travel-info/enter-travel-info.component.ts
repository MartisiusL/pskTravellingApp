import { Component, OnInit, ViewChild } from '@angular/core';
import { TripService } from '../trip.service';
import { OfficeService } from '../office.service';

@Component({
  selector: 'app-enter-travel-info',
  templateUrl: './enter-travel-info.component.html',
  styleUrls: ['./enter-travel-info.component.css']
})
export class EnterTravelInfoComponent implements OnInit {
	
  date = new Date();
  
  tripInfo = {};
  offices = []
  
  @ViewChild('files') filesContainer: Object;
  @ViewChild('fileInput') fileInput: Object;
  
  
  constructor(private tripService: TripService, private officeService: OfficeService) {
  }
  

  ngOnInit() {
    this.getOffices()
  }

  getOffices(): void {
    this.officeService.getOffices().subscribe(offices => this.offices = offices);
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
	  alert("qwertyuio");
  }
  

}
