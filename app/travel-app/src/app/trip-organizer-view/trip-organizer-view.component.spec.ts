import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TripOrganizerViewComponent } from './trip-organizer-view.component';

describe('TripOrganizerViewComponent', () => {
  let component: TripOrganizerViewComponent;
  let fixture: ComponentFixture<TripOrganizerViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TripOrganizerViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TripOrganizerViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
