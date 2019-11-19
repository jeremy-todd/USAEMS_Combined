import { TestBed } from '@angular/core/testing';
import { AuthServiceService } from './auth-service.service';
describe('AuthServiceService', () => {
    beforeEach(() => TestBed.configureTestingModule({}));
    it('should be created', () => {
        const service = TestBed.get(AuthServiceService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=auth-service.service.spec.js.map