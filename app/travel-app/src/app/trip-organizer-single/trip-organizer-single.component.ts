import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TripService, Trip } from '../trip.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-trip-organizer-single',
  templateUrl: './trip-organizer-single.component.html',
  styleUrls: ['./trip-organizer-single.component.css']
})
export class TripOrganizerSingleComponent implements OnInit {
	
  trip = {}
  trips = []
  currentTripId: number

  tripToCombine: number

  constructor(private route: ActivatedRoute,
    private tripService: TripService, 
    private authService: AuthService) { }

  ngOnInit() {
    this.getTrip();
  }
  
  getTrip(){
	  const id = +this.route.snapshot.paramMap.get('id');
	  this.tripService.getTripForOrganizer(id).subscribe(trip => {
      this.trip = trip;
      this.currentTripId = trip.Id
      this.getTrips();
		});
  }

  getTrips(): void {
    this.tripService.getTripsByOrganizerId(this.authService.getCurrentUserId()).subscribe(trips => {
      this.trips = trips.filter(t => t.Id !== this.currentTripId)
    });
  }

  mergeTrips() {
    this.tripService.mergeTrips({firstTripId:this.currentTripId, secondTripId:this.tripToCombine}).subscribe(data => {
      if(data.success) {
        alert(data.message)
      }
      else {
        alert(data.message)
      }
    })
  }
}
