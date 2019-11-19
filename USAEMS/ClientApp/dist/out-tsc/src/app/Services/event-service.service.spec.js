import { TestBed } from '@angular/core/testing';
import { EventServiceService } from './event-service.service';
describe('EventServiceService', () => {
    beforeEach(() => TestBed.configureTestingModule({}));
    it('should be created', () => {
        const service = TestBed.get(EventServiceService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=event-service.service.spec.js.map