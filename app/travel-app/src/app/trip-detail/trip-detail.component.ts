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
  myTrip: Trip

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
    this.tripService.getTrip(id).subscribe(trip => {
      this.myTrip = trip;
      console.log(trip)
    });
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    console.log(this.myTrip)
    this.tripService.updateName(this.myTrip.TripName, this.myTrip.Id, this.myTrip.RowVersion).subscribe(data => {
      if(data.success) {
        alert("Successfully updated")
      } else {
        if(confirm("This data table was overwritten, do you want to force push?")) {
          this.tripService.forceUpdateName(this.myTrip.TripName, this.myTrip.Id, this.myTrip.RowVersion).subscribe(data => {
            if(data.success) {
              alert("Successfully updated")
            } else {
              alert(data.message)
            }
          })
        } else {
          location.reload()
        }
      }
    })
    //this.tripService.updateTrip(this.trip)
     // .subscribe(() => this.goBack());
  }
}

export interface Trip{
  TripStartDate: Date;
  TripEndDate: Date;
	ToOfficeId: number;
	FromOfficeId: number;
	TripName: string;
	Id: number;
	confirmed: boolean;
  UserTripId: number;
  RowVersion: any[];
}
