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

  private loggedInStatus = false
  private isAdmin = false
  private currentUserId: Number

  constructor(private http: HttpClient) { }

  setLoggedIn(value: boolean) {
    this.loggedInStatus = value
  }

  setCurrentUserId(Id: Number) {
    this.currentUserId = Id
  }

  getCurrentUserId() {
    return this.currentUserId
  }

  setIsAdmin(value: boolean) {
    this.isAdmin = true
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
