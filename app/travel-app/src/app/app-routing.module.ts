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
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  { path: 'trips', component: MyTripsComponent, canActivate: [AuthGuard] },
  { path: 'detail/:id', component: TripDetailComponent, canActivate: [AuthGuard] },
  { path: 'reports', component: MessagesComponent, canActivate: [AuthGuard] },
  { path:"travel", component: EnterTravelInfoComponent, canActivate: [AuthGuard]},
  { path: "login", component: LoginComponent},
  { path: '',   redirectTo: '/login', pathMatch: 'full' },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'register', component: RegisterComponent }
]


@NgModule({
  imports: [RouterModule.forRoot(routes), FormsModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
