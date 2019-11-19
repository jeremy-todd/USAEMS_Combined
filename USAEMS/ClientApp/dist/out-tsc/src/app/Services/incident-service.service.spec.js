import { TestBed } from '@angular/core/testing';
import { IncidentServiceService } from './incident-service.service';
describe('IncidentServiceService', () => {
    beforeEach(() => TestBed.configureTestingModule({}));
    it('should be created', () => {
        const service = TestBed.get(IncidentServiceService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=incident-service.service.spec.js.map