import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { TripService, Trip } from '../trip.service';

@Component({
  selector: 'app-trip-detail',
  templateUrl: './trip-detail.component.html',
  styleUrls: ['./trip-detail.component.css']
})
export class TripDetailComponent implements OnInit {

  @Input() trip: Trip;

  /* @Task same as with home page. The info here is provided you can easily access it and see how it is 
  received, take this task and make this screen design look good enough.  */

  constructor(  
    private route: ActivatedRoute,
    private tripService: TripService,
    private location: Location
    ) { }

  ngOnInit() {
    this.getTrip();
  }

  getTrip(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.tripService.getTrip(id).subscribe(trip => this.trip = trip);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    //this.tripService.updateTrip(this.trip)
     // .subscribe(() => this.goBack());
  }
}
