import { Component, OnInit, ViewChild } from '@angular/core';
import { TripService } from '../trip.service';
import { OfficeService } from '../office.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-enter-travel-info',
  templateUrl: './enter-travel-info.component.html',
  styleUrls: ['./enter-travel-info.component.css']
})
export class EnterTravelInfoComponent implements OnInit {
	
  date = new Date();
  
  tripInfo = {};
  offices = []
  users = []
  usersDropDownList = []

  dropdownList = [];
  selectedItems = [];
  dropdownSettings = {};
  
  @ViewChild('files') filesContainer: Object;
  @ViewChild('fileInput') fileInput: Object;
  
  
  constructor(private tripService: TripService, private officeService: OfficeService, private userService: UserService) {
  }
  

  ngOnInit() {
    this.getOffices()
    this.getEmployees()
  }

  getOffices(): void {
    this.officeService.getOffices().subscribe(offices => {this.offices = offices; console.log(offices)});
  }

  getEmployees(): void {
    this.userService.getUsers().subscribe(users => {
      this.users = users


      this.users.forEach(user => {
        this.usersDropDownList.push({ item_id: user.Id, item_text: user.Name})
      });

      this.dropdownSettings = {
        singleSelection: false,
        idField: 'item_id',
        textField: 'item_text',
        selectAllText: 'Select All',
        unSelectAllText: 'UnSelect All',
        itemsShowLimit: 10
      };
    })
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
  
  onRegisterTripClick() {
	  console.log(this.tripInfo)
  }
  

}
