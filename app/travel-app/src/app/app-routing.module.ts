import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { EnterTravelInfoComponent } from './enter-travel-info/enter-travel-info.component';

const routes: Routes = [
	{path:"travel", component: EnterTravelInfoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes), FormsModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
