import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})

export class TripService {

  private tripsUrl = 'http://localhost:55155/api/trip';

  constructor(
  private http: HttpClient,
  private messageService: MessageService) { }

  getTrips(): Observable<Trip[]>{
    return this.http.get<Trip[]>(this.tripsUrl);
  }
  
  getTrip(id: number): Observable<Trip>{
    return this.http.get<Trip>(this.tripsUrl + "/" + id);
  }
  
  postTrip(trip: Trip){
	  this.http.post(this.tripsUrl, trip, httpOptions).subscribe();
  }
}

export interface Trip{
	date: Date;
	toOffice: object;
	fromOffice: object;
	name: string;
	ID: number;
	peopleAnswersForTheTrip: Array<boolean>;
	peopleOfTheTrip: Array<object>;
}
