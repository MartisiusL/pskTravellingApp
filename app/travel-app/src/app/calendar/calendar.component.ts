import {
  Component,
  ChangeDetectionStrategy,
  ViewChild,
  TemplateRef,
  ChangeDetectorRef
} from '@angular/core';
import {
  startOfDay,
  endOfDay,
  subDays,
  addDays,
  endOfMonth,
  isSameDay,
  isSameMonth,
  addHours
} from 'date-fns';
import { Subject } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {
  CalendarEvent,
  CalendarEventAction,
  CalendarEventTimesChangedEvent,
  CalendarView
} from 'angular-calendar';
import { AvailabilityService } from '../availability.service';
import { AuthService } from '../auth.service';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../user.service';

const colors: any = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3'
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF'
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA'
  }
};

@Component({
  selector: 'calendar-component',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarComponent {
  @ViewChild('modalContent') modalContent: TemplateRef<any>;

  view: CalendarView = CalendarView.Month;

  CalendarView = CalendarView;

  viewDate: Date = new Date();

  newStartDate: Date = new Date();
  newEndDate: Date = new Date();
  newTitle: string = "New Event";
  newEvent: boolean = false;

  canCreateNew: boolean = true;
  currentUserName: string;

  modalData: {
    action: string;
    event: CalendarEvent;
  };

  ngOnInit() {
    if(this.route.snapshot.paramMap.get('id') == null) {
      this.getAvailability()
      console.log(this.authService.getCurrentUserId())
      this.userService.getUserName(this.authService.getCurrentUserId()).subscribe(data =>
        {
          this.currentUserName = data.toString()
          this.ref.detectChanges()
        })
    } else {
      this.getAvailabilityById(+this.route.snapshot.paramMap.get('id'))
      this.userService.getUserName(+this.route.snapshot.paramMap.get('id')).subscribe(data =>
        {
          this.currentUserName = data.toString()
          this.ref.detectChanges()
        })
      this.canCreateNew = false;
    }
  }

  createNewEvent() {
    this.newEvent = true;
  }

  getAvailabilityById(id: number) {
    this.availabilityService.getAvailabilityList(id)
    .subscribe(availabilities => {

      availabilities.forEach(element => {
        this.events = [
          ...this.events,
          {
            title: element.title,
            start: startOfDay(element.start),
            end: endOfDay(element.end)
          }
        ];
      });
      this.ref.detectChanges()
    });
  }

  getAvailability() {
    this.availabilityService.getAvailabilityList(this.authService.getCurrentUserId())
    .subscribe(availabilities => {

      availabilities.forEach(element => {
        this.events = [
          ...this.events,
          {
            title: element.title,
            start: startOfDay(element.start),
            end: endOfDay(element.end)
          }
        ];
      });
      this.ref.detectChanges()
    });
  }

  events: CalendarEvent[] = [];

  actions: CalendarEventAction[] = [
    {
      label: '<i class="fa fa-fw fa-pencil"></i>',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('Edited', event);
      }
    },
    {
      label: '<i class="fa fa-fw fa-times"></i>',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.events = this.events.filter(iEvent => iEvent !== event);
        this.handleEvent('Deleted', event);
      }
    }
  ];

  refresh: Subject<any> = new Subject();

  activeDayIsOpen: boolean = false;

  constructor(private modal: NgbModal,
     private availabilityService: AvailabilityService,
      private authService: AuthService,
       private ref: ChangeDetectorRef,
       private route: ActivatedRoute, 
       private userService: UserService) {
  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      this.viewDate = date;
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
    }
  }

  eventTimesChanged({
    event,
    newStart,
    newEnd
  }: CalendarEventTimesChangedEvent): void {
    this.events = this.events.map(iEvent => {
      if (iEvent === event) {
        return {
          ...event,
          start: newStart,
          end: newEnd
        };
      }
      return iEvent;
    });
    this.handleEvent('Dropped or resized', event);
  }

  handleEvent(action: string, event: CalendarEvent): void {
    this.modalData = { event, action };
    this.modal.open(this.modalContent, { size: 'lg' });
  }

  addEvent(): void {
    console.log(this.authService.getCurrentUserId())
    this.availabilityService.postAvailability({Title: this.newTitle, BusyFrom: this.newStartDate, BusyTo: this.newEndDate, UserId: this.authService.getCurrentUserId()})
    .subscribe(answerData => {
      if(answerData.success) {
        this.events = [
          ...this.events,
          {
            title: this.newTitle,
            start: startOfDay(this.newStartDate),
            end: endOfDay(this.newEndDate)
          }
        ];
        this.resetNewEvent()
        alert("Success")
        this.ref.detectChanges()
      } else  {
        alert("Something went wrong!")
      }
    })
  }

  resetNewEvent() {
    this.newEvent = false;
    this.newTitle = "New Event"
    this.newStartDate = new Date()
    this.newEndDate = new Date()
  }

  deleteEvent(eventToDelete: CalendarEvent) {
    this.events = this.events.filter(event => event !== eventToDelete);
  }

  setView(view: CalendarView) {
    this.view = view;
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }
}