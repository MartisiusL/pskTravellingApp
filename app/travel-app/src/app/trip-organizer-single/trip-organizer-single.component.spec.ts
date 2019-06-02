import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TripOrganizerSingleComponent } from './trip-organizer-single.component';

describe('TripOrganizerSingleComponent', () => {
  let component: TripOrganizerSingleComponent;
  let fixture: ComponentFixture<TripOrganizerSingleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TripOrganizerSingleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TripOrganizerSingleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
