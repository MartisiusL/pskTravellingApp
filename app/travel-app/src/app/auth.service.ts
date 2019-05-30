import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

interface myData {
  success: boolean,
  admin: boolean,
  userId: number, 
  message: string
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loggedInStatus = JSON.parse(localStorage.getItem('loggedInStatus') || 'false')
  private isAdmin = JSON.parse(localStorage.getItem('isAdmin') || 'false')
  private currentUserId: number = JSON.parse(localStorage.getItem('currentUserId') || '-1')

  constructor(private http: HttpClient) { }

  setLoggedIn(value: boolean) {
    this.loggedInStatus = value
    if(value)
      localStorage.setItem('loggedInStatus', value.toString());
    else {
      localStorage.removeItem('loggedInStatus')
      localStorage.removeItem('currentUserId')
      localStorage.removeItem('isAdmin')
    }  
  }

  setCurrentUserId(Id: number) {
    this.currentUserId = Id
    localStorage.setItem('currentUserId', Id.toString());
  }

  getCurrentUserId() {
    return this.currentUserId
  }

  setIsAdmin(value: boolean) {
    this.isAdmin = true
    localStorage.setItem('isAdmin', value.toString());
  }

  get IsAdmin() {
    return this.isAdmin
  }

  get isLoggedIn() {
    return this.loggedInStatus
  }

  getUserDetails(username, password) {
    return this.http.post<myData>('http://localhost:55155/api/authorization', {
      username,
      password
    })
  }
}
