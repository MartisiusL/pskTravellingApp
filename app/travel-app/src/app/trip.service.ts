import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Trip } from './trip';
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

  private tripsUrl = 'api/trips';

  constructor(
  private http: HttpClient,
  private messageService: MessageService) { }

  getTrips(): Observable<Trip[]> {
    return this.http.get<Trip[]>(this.tripsUrl)
    .pipe(
      tap(_ => this.log('fetched trips')),
      catchError(this.handleError<Trip[]>('getTrips', []))
    );
    //return of(TRIPS);
  }

  private log(message: string) {
    this.messageService.add(`TripService: ${message}`);
  }

  getTrip(id: number): Observable<Trip> {
    const url = `${this.tripsUrl}/${id}`;
    return this.http.get<Trip>(url).pipe(
      tap(_ => this.log(`fetched trip id=${id}`)),
      catchError(this.handleError<Trip>(`getTrip id=${id}`))
    );
  }

  /** PUT: update the trip on the server */
  updateTrip (trip: Trip): Observable<any> {
    return this.http.put(this.tripsUrl, trip, httpOptions).pipe(
      tap(_ => this.log(`updated trip id=${trip.id}`)),
      catchError(this.handleError<any>('updateTrip'))
    );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
   
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
   
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
   
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** POST: add a new trip to the server */
addTrip (trip: Trip): Observable<Trip> {
  return this.http.post<Trip>(this.tripsUrl, trip, httpOptions).pipe(
    tap((newTrip: Trip) => this.log(`added trip w/ id=${newTrip.id}`)),
    catchError(this.handleError<Trip>('addTrip'))
  );
}

/** DELETE: delete the trip from the server */
deleteTrip (trip: Trip | number): Observable<Trip> {
  const id = typeof trip === 'number' ? trip : trip.id;
  const url = `${this.tripsUrl}/${id}`;

  return this.http.delete<Trip>(url, httpOptions).pipe(
    tap(_ => this.log(`deleted trip id=${id}`)),
    catchError(this.handleError<Trip>('deleteTrip'))
  );
}

/* GET trips whose name contains search term */
searchTrips(term: string): Observable<Trip[]> {
  if (!term.trim()) {
    // if not search term, return empty trip array.
    return of([]);
  }
  return this.http.get<Trip[]>(`${this.tripsUrl}/?name=${term}`).pipe(
    tap(_ => this.log(`found trips matching "${term}"`)),
    catchError(this.handleError<Trip[]>('searchTrips', []))
  );
}

}
