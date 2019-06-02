import { Component, OnInit, ViewChild } from '@angular/core';
import { TripService } from '../trip.service';
import { OfficeService } from '../office.service';
import { UserService } from '../user.service';
import { AuthService } from '../auth.service';

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

  selectedItems = [];
  settings = {};
  
  @ViewChild('files') filesContainer: Object;
  @ViewChild('fileInput') fileInput: Object;
  
  
  constructor(private tripService: TripService, private officeService: OfficeService, private userService: UserService,private authService: AuthService) {
  }
  

  ngOnInit() {
    this.getOffices()
    this.getEmployees()

      this.settings = { 
        singleSelection: false
      }; 
  }

  getOffices(): void {
    this.officeService.getOffices().subscribe(offices => {this.offices = offices});
  }

  getEmployees() {
    this.userService.getUsers().subscribe(users => {
      this.users = users
      this.users.forEach(user => {
        this.usersDropDownList.push({ "id": user.Id, "itemName": user.Name})
      }); 
      console.log(this.usersDropDownList)  
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
	//this.tripInfo.OrganizerId = this.authService.getCurrentUserId();
    var tripContract = Object.assign(this.tripInfo, {"selectedItems" :this.selectedItems, "OrganizerId" : this.authService.getCurrentUserId()});
    this.tripService.registerTrip(tripContract).subscribe(data => {
      alert(data.message)
      window.location.reload();
    });
  }
}
