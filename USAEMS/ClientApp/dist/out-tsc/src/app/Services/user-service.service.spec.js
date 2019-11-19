import { TestBed } from '@angular/core/testing';
import { UserServiceService } from './user-service.service';
describe('UserServiceService', () => {
    beforeEach(() => TestBed.configureTestingModule({}));
    it('should be created', () => {
        const service = TestBed.get(UserServiceService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=user-service.service.spec.js.map