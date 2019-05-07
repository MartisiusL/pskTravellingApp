import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EnterTravelInfoComponent } from './enter-travel-info/enter-travel-info.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    EnterTravelInfoComponent
  ],
  imports: [
	FormsModule,
	ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule
	
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { } 
