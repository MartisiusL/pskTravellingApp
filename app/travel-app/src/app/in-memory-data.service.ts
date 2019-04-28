import { InMemoryDbService } from 'angular-in-memory-web-api'
import { Injectable } from '@angular/core';
import { Trip } from './trip';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const trips = [
      { id: 11, name: 'Vilnius', confirmed: false },
      { id: 12, name: 'Kaunas', confirmed: false },
      { id: 13, name: 'Klaipeda', confirmed: false },
      { id: 14, name: 'Siauliai', confirmed: false },
      { id: 15, name: 'Panevezys', confirmed: false },
      { id: 16, name: 'Taurage', confirmed: false },
      { id: 17, name: 'Alytus', confirmed: false },
      { id: 18, name: 'Palanga', confirmed: false },
      { id: 19, name: 'Marijampole', confirmed: false },
      { id: 20, name: 'Utena', confirmed: false }
    ];
    return {trips};
  }

  genId(trips: Trip[]): number {
    return trips.length > 0 ? Math.max(...trips.map(trip => trip.id)) + 1 : 11;
  }
}