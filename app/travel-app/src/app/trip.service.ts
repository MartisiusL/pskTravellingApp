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
  private tripsByUserIdUrl = 'http://localhost:55155/api/tripbyuserid';
  
  constructor(
  private http: HttpClient,
  private messageService: MessageService) { }

  getTrips(): Observable<Trip[]>{
    return this.http.get<Trip[]>(this.tripsUrl);
  }
  
  getTrip(id: number): Observable<Trip>{
    return this.http.get<Trip>(this.tripsUrl + "/" + id);
  }
  
  getTripsByUserId(id: number){
	  return this.http.get<Trip[]>(this.tripsByUserIdUrl + "/" + id);
  }
  
  postTrip(trip: Trip){
	  this.http.post(this.tripsUrl, trip, httpOptions).subscribe();
  }

  registerTrip(tripContract: any) {
    return this.http.post<answerForRegistation>(this.tripsUrl, tripContract, httpOptions);
  }
  
  putUserTrip(trip: Trip){	  
	  this.http.put(this.tripsByUserIdUrl + "/" + trip.UserTripId, {"confirmed": trip.confirmed}, httpOptions).subscribe();
  }
}

interface answerForRegistation {
  success: boolean,
  message: string
}

export interface TripInfo {
  TripName: string;
  TripStartDate: Date;
  TripEndDate: Date;
  ToOfficeId: number;
  FromOfficeId: number;
  Hotel: boolean;
  Car: boolean;
  Travel: boolean;
}

export interface TripContract{
  TripName: string;
  TripStartDate: Date;
  TripEndDate: Date;
  ToOfficeId: number;
  FromOfficeId: number;
  Hotel: boolean;
  Car: boolean;
  Travel: boolean;
  users: any[]
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
}
