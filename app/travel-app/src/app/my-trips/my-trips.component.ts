import { Component, OnInit } from '@angular/core';
import { TripService, Trip } from '../trip.service';

@Component({
  selector: 'app-my-trips',
  templateUrl: './my-trips.component.html',
  styleUrls: ['./my-trips.component.css']
})
export class MyTripsComponent implements OnInit {

  trips = [];

  constructor(private tripService: TripService) { }

  ngOnInit() {
    this.getTrips();
  }

  getTrips(): void {
    this.tripService.getTrips().subscribe(trips => this.trips = trips);
	this.tripService.postTrip({ID:  123});
  }
}
