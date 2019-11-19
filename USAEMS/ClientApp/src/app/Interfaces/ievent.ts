import { Time } from '@angular/common';

export interface IEvent {
    eventId: Number;
    eventName: String;
    eventDate: Date;
    eventTime: Time;
    eventType: String;
}
