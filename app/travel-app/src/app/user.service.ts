import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private userUrl = 'http://localhost:55155/api/user';
  private userUrlName = 'http://localhost:55155/api/username'

  constructor(private http: HttpClient) { }

  getUserDetails(newUser) {
    console.log(newUser)
    return this.http.post<RegisterUserData>('http://localhost:55155/api/User', newUser)
  }

  getUsers(): Observable<User[]>{
    return this.http.get<User[]>(this.userUrl);
  }

  getUserName(id: number) {
    return this.http.get(this.userUrlName + "/" + id.toString())
  }
}

export interface User{
  Account: {};
  UserTrips: [];
  Id: number;
	Name: string;
  Surname: string;
  PhoneNumber: string;
  IsAdmin: boolean;
  AccountId: number;
}

interface RegisterUserData {
  success: boolean,
  userId: number
}
