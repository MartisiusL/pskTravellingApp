import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MessageService } from './message.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OfficeService {

  private officeUrl = 'http://localhost:55155/api/office';

  constructor(
  private http: HttpClient,
  private messageService: MessageService) { }

  getOffices(): Observable<Office[]>{
    return this.http.get<Office[]>(this.officeUrl);
  }
  
  getOffice(id: number): Observable<Office>{
    return this.http.get<Office>(this.officeUrl + "/" + id);
  }
}

export interface Office{
	OfficeName: string;
	OfficeAddress: string;
	Id: number;
}