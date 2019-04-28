import { Component, OnInit } from '@angular/core';
 
import { Observable, Subject } from 'rxjs';
 
import {
   debounceTime, distinctUntilChanged, switchMap
 } from 'rxjs/operators';
 
import { Trip } from '../trip';
import { TripService } from '../trip.service';
 
@Component({
  selector: 'app-trip-search',
  templateUrl: './trip-search.component.html',
  styleUrls: [ './trip-search.component.css' ]
})
export class TripSearchComponent implements OnInit {
  trips$: Observable<Trip[]>;
  private searchTerms = new Subject<string>();
 
  constructor(private tripService: TripService) {}
 
  // Push a search term into the observable stream.
  search(term: string): void {
    this.searchTerms.next(term);
  }
 
  ngOnInit(): void {
    this.trips$ = this.searchTerms.pipe(
      // wait 300ms after each keystroke before considering the term
      debounceTime(300),
 
      // ignore new term if same as previous term
      distinctUntilChanged(),
 
      // switch to new search observable each time the term changes
      switchMap((term: string) => this.tripService.searchTrips(term)),
    );
  }
}