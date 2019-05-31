import { Component, OnInit } from '@angular/core';
import { TripService, Trip } from '../trip.service';
import { AuthService } from '../auth.service';
import {formatDate} from '@angular/common';

@Component({
  selector: 'app-my-trips',
  templateUrl: './my-trips.component.html',
  styleUrls: ['./my-trips.component.css']
})
export class MyTripsComponent implements OnInit {

  /*It should be not trips, but rather UserTrip to make Many to Many relationship
  then this would be called to the back end to get the list of UserTrip where contents would be
  UserId and TripId and whether this is confirmed. So after getting this list, then the list of
  trips should be generated, where we know whether the user confirmed it or not and a put method
  should be called to the database. It would be pretty good place to implement optimistic lock variants
  where we can cancel, refresh and do it again or just force. @Task @Liutauras.
  */
 trips = [];

  constructor(private tripService: TripService, private authService: AuthService) { }

  ngOnInit() {
    this.getTrips();
  }

  getTrips(): void {
    this.tripService.getTripsByUserId(this.authService.getCurrentUserId()).subscribe(trips => {
      this.trips = trips
      console.log(trips)
    });
      
  }

  getTripStatus(trip) {
    console.log(formatDate(trip.TripEndDate, 'yyyy/MM/dd', 'en') + " and " +  formatDate(new Date(), 'yyyy/MM/dd', 'en'))
    if(formatDate(trip.TripEndDate, 'yyyy/MM/dd', 'en') < formatDate(new Date(), 'yyyy/MM/dd', 'en')) {
      return "Trip ended"
    } else if(formatDate(trip.TripStartDate, 'yyyy/MM/dd', 'en') < formatDate(new Date(), 'yyyy/MM/dd', 'en')){
      return "Trip started"
    } else {
      return "Trip awaiting"
    }
  }

  getTripStatusBool(trip) {
    if(formatDate(trip.TripStartDate, 'yyyy/MM/dd', 'en') < formatDate(new Date(), 'yyyy/MM/dd', 'en'))
      return false
    if(formatDate(trip.TripEndDate, 'yyyy/MM/dd', 'en') < formatDate(new Date(), 'yyyy/MM/dd', 'en'))
      return false
    
    return true
  }
  
  confirm(trip){
	  trip.confirmed = false;
	  this.tripService.putUserTrip(trip);
	  console.log(trip);
  }
  
  refuse(trip){
	  trip.confirmed = true;
	  this.tripService.putUserTrip(trip);
  }
}
