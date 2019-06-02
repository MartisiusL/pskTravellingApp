import { Component, OnInit, ViewChild } from '@angular/core';
import { TripService } from '../trip.service';
import { OfficeService } from '../office.service';
import { UserService } from '../user.service';
import { AuthService } from '../auth.service';
import { AvailabilityService } from '../availability.service';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

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

  closeResult: string;
  
  
  constructor(private tripService: TripService,
     private officeService: OfficeService,
      private userService: UserService,
      private availabilityService: AvailabilityService,
      private modalService: NgbModal,
	  private authService: AuthService) {
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
    console.log("started getting employees")
    this.userService.getUsers().subscribe(users => {
      this.users = users
      this.users.forEach(user => {
        this.usersDropDownList.push({ "id": user.Id, "itemName": user.Name})
      }); 
      console.log(this.usersDropDownList)  
    })
  }

  checkAvailability(id: number) {
    window.open("http://localhost:4200/calendar/" + id.toString());
  }
  
  ngAfterViewInit(){
	  console.log(this.tripInfo);
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
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
