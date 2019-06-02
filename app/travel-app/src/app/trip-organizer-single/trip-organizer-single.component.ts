import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TripService, Trip } from '../trip.service';

@Component({
  selector: 'app-trip-organizer-single',
  templateUrl: './trip-organizer-single.component.html',
  styleUrls: ['./trip-organizer-single.component.css']
})
export class TripOrganizerSingleComponent implements OnInit {
	
	trip = {}

  constructor(private route: ActivatedRoute,
    private tripService: TripService) { }

  ngOnInit() {
	  this.getTrip();
  }
  
  getTrip(){
	  const id = +this.route.snapshot.paramMap.get('id');
	  this.tripService.getTripForOrganizer(id).subscribe(trip => {
		  this.trip = trip;
		  console.log(trip)
		});
  }

}
