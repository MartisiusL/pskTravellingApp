import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EnterTravelInfoComponent } from './enter-travel-info.component';

describe('EnterTravelInfoComponent', () => {
  let component: EnterTravelInfoComponent;
  let fixture: ComponentFixture<EnterTravelInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EnterTravelInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnterTravelInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
