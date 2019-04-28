import { InMemoryDbService } from 'angular-in-memory-web-api'
import { Injectable } from '@angular/core';
import { Trip } from './trip';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const trips = [
      { id: 11, name: 'Vilnius' },
      { id: 12, name: 'Kaunas' },
      { id: 13, name: 'Klaipeda' },
      { id: 14, name: 'Siauliai' },
      { id: 15, name: 'Panevezys' },
      { id: 16, name: 'Taurage' },
      { id: 17, name: 'Alytus' },
      { id: 18, name: 'Palanga' },
      { id: 19, name: 'Marijampole' },
      { id: 20, name: 'Utena' }
    ];
    return {trips};
  }
  
  genId(trips: Trip[]): number {
    return trips.length > 0 ? Math.max(...trips.map(trip => trip.id)) + 1 : 11;
  }
}