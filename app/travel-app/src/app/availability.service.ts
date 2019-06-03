import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class AvailabilityService {

  private availabilityUrl = 'http://localhost:55155/api/availability';
  private availabilityDeleteUrl = 'http://localhost:55155/api/availabilityDelete'

  constructor(private http: HttpClient) { }

  getAvailabilityList(id: number) {
    return this.http.get<Availability[]>(this.availabilityUrl + "/" + id);
  }

  postAvailability(availability: AvailabilityContract) {
	  return this.http.post<answerData>(this.availabilityUrl, availability, httpOptions)
  }

  deleteAvailability(id: string | number) {
    console.log(this.availabilityUrl + "/" +  id)
   return this.http.post(this.availabilityDeleteUrl + "/" +  id, null)
  }
}

export interface Availability{
  title: string;
  start: Date;
  end: Date;
  availabilityId: number;
}

export interface AvailabilityContract{
  Title: string;
  BusyFrom: Date;
  BusyTo: Date;
  UserId: number;
}

interface answerData{
  success: boolean,
  message: string
}
