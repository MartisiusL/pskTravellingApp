import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyTripsComponent } from './my-trips/my-trips.component'
import { TripDetailComponent } from './trip-detail/trip-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { FormsModule } from '@angular/forms';
import { EnterTravelInfoComponent } from './enter-travel-info/enter-travel-info.component';

const routes: Routes = [
  { path: '', redirectTo: '/trips', pathMatch: 'full' },
  { path: 'trips', component: MyTripsComponent },
  { path: 'detail/:id', component: TripDetailComponent },
  { path: 'reports', component: MessagesComponent },
  {path:"travel", component: EnterTravelInfoComponent}
]


@NgModule({
  imports: [RouterModule.forRoot(routes), FormsModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
