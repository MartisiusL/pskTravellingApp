import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyTripsComponent } from './my-trips/my-trips.component'
import { TripDetailComponent } from './trip-detail/trip-detail.component';
import { MessagesComponent } from './messages/messages.component';

const routes: Routes = [
  { path: '', redirectTo: '/trips', pathMatch: 'full' },
  { path: 'trips', component: MyTripsComponent },
  { path: 'detail/:id', component: TripDetailComponent },
  { path: 'reports', component: MessagesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
