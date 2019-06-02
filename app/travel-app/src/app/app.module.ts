import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MyTripsComponent } from './my-trips/my-trips.component';
import { TripDetailComponent } from './trip-detail/trip-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { HttpClientModule }    from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { EnterTravelInfoComponent } from './enter-travel-info/enter-travel-info.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from './auth.service';
import { AuthGuard } from './auth.guard';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { CalendarComponent } from './calendar/calendar.component';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { FlatpickrModule } from 'angularx-flatpickr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    EnterTravelInfoComponent,
    HeaderComponent,
    SidebarComponent,
    MyTripsComponent,
    TripDetailComponent,
    MessagesComponent,
    LoginComponent,
    HomeComponent,
    RegisterComponent,
    CalendarComponent,
  ],
  imports: [
	FormsModule,
	ReactiveFormsModule,
  BrowserModule,
  AppRoutingModule,
  HttpClientModule,
  NgbModule.forRoot(),
  NgMultiSelectDropDownModule.forRoot(),
  AngularMultiSelectModule, 
  NgbModalModule,
  FlatpickrModule.forRoot(),   
  CalendarModule.forRoot({
    provide: DateAdapter,
    useFactory: adapterFactory
  }),
  BrowserAnimationsModule
  ],
  providers: [AuthService, AuthGuard, HeaderComponent],
  bootstrap: [AppComponent]
})
export class AppModule { } 
