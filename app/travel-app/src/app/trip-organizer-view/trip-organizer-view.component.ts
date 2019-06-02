import { Component, OnInit } from '@angular/core';
import { TripService, Trip } from '../trip.service';
import { AuthService } from '../auth.service';
import {formatDate} from '@angular/common';

@Component({
  selector: 'app-trip-organizer-view',
  templateUrl: './trip-organizer-view.component.html',
  styleUrls: ['./trip-organizer-view.component.css']
})
export class TripOrganizerViewComponent implements OnInit {
	
	trips = []

  constructor(private tripService: TripService, private authService: AuthService) { }

  ngOnInit() {
	  this.getTrips();
  }
  
  getTrips(): void {
    this.tripService.getTripsByOrganizerId(this.authService.getCurrentUserId()).subscribe(trips => {
      this.trips = trips
      console.log(trips)
    });
      
  }

}
