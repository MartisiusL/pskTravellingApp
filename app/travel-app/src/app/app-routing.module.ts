import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyTripsComponent } from './my-trips/my-trips.component';
import { TripDetailComponent } from './trip-detail/trip-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { FormsModule } from '@angular/forms';
import { EnterTravelInfoComponent } from './enter-travel-info/enter-travel-info.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { TripOrganizerViewComponent } from './trip-organizer-view/trip-organizer-view.component';
import { TripOrganizerSingleComponent } from './trip-organizer-single/trip-organizer-single.component';
import { AuthGuard } from './auth.guard';
import { CalendarComponent } from './calendar/calendar.component';

const routes: Routes = [
  { path: 'trips', component: MyTripsComponent, canActivate: [AuthGuard] },
  { path: 'detail/:id', component: TripDetailComponent, canActivate: [AuthGuard] },
  { path: 'reports', component: MessagesComponent, canActivate: [AuthGuard] },
  { path: 'organizer', component: TripOrganizerViewComponent, canActivate: [AuthGuard] },
  { path: 'organizerdetail/:id', component: TripOrganizerSingleComponent, canActivate: [AuthGuard] },
  { path:"travel", component: EnterTravelInfoComponent, canActivate: [AuthGuard]},
  { path: "login", component: LoginComponent},
  { path: '',   redirectTo: '/login', pathMatch: 'full' },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'register', component: RegisterComponent },
  { path: 'calendar', component: CalendarComponent, canActivate: [AuthGuard]},
  { path: 'calendar/:id', component: CalendarComponent, canActivate: [AuthGuard]}
]


@NgModule({
  imports: [RouterModule.forRoot(routes), FormsModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
