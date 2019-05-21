import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

interface myData {
  success: boolean,
  message: string
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  loggedInStatus = false;
  headers = new HttpHeaders();
  

  setLoggedIn(value: boolean) {
    this.loggedInStatus = value
  }

  get isLoggedIn() {
    return this.loggedInStatus
  }

  getUserDetails(usernamex, passwordx) {
    console.log(usernamex + passwordx);
    //this.headers.append('Content-Type', 'application/x-www-form-urlencoded');
    const url = "http://localhost:55155/api/authorization"

    return this.http.post<myData>(url,
    {username: 'admin', password: 'admin'}
    //{ headers:this.headers}
    )
    //return this.http.get("http://localhost:55155/api/authorization", {headers: this.headers});
  } 
}
