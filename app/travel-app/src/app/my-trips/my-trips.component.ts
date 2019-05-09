import { Component, OnInit } from '@angular/core';
import { Trip } from '../trip'
import { TripService } from '../trip.service';

@Component({
  selector: 'app-my-trips',
  templateUrl: './my-trips.component.html',
  styleUrls: ['./my-trips.component.css']
})
export class MyTripsComponent implements OnInit {

  trips: Trip[];

  constructor(private tripService: TripService) { }

  ngOnInit() {
    this.getTrips();
  }

  getTrips(): void {
    this.tripService.getTrips()
    .subscribe(trips => this.trips = trips);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.tripService.addTrip({ name } as Trip)
      .subscribe(trip => {
        this.trips.push(trip);
      });
  }

  delete(trip: Trip): void {
    this.trips = this.trips.filter(h => h !== trip);
    this.tripService.deleteTrip(trip).subscribe();
  }

  refuse(trip: Trip): void {
    trip.confirmed = true;
    this.tripService.refuseTrip(trip).subscribe();
  }

  confirm(trip: Trip): void {
    trip.confirmed = false;
    this.tripService.refuseTrip(trip).subscribe();
  }
}
