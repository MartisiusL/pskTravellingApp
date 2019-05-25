import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUserDetails(newUser) {
    console.log(newUser)
    return this.http.post('http://localhost:55155/api/User', newUser)
  }
}
