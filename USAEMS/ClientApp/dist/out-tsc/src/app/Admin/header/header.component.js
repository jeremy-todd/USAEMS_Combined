import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let HeaderComponent = class HeaderComponent {
    constructor(AuthService, UserService) {
        this.AuthService = AuthService;
        this.UserService = UserService;
        this.user = {
            id: "",
            firstName: "",
            lastName: "",
            securityQuestion: 0,
            securityAnswer: "",
            email: "",
            phoneNumber: "",
            carrierId: 0,
            student: false,
            technical: false,
            employerId: 0,
            active: false
        };
    }
    ngOnInit() {
        this.AuthService.currentUser.subscribe((currentUser) => {
            this.user.id = currentUser.user.id;
            this.user.firstName = currentUser.user.firstName;
            this.user.lastName = currentUser.user.lastName;
            this.user.securityQuestion = currentUser.user.securityQuestion;
            this.user.securityAnswer = currentUser.user.securityAnswer;
            this.user.email = currentUser.user.email;
            this.user.phoneNumber = currentUser.user.phoneNumber;
            this.user.carrierId = currentUser.user.carrierId;
            this.user.student = currentUser.user.student;
            this.user.technical = currentUser.user.technical;
            this.user.employerId = currentUser.user.employerId;
            this.user.active = currentUser.user.active;
        });
    }
    signOut() {
        this.AuthService.logout();
    }
};
HeaderComponent = tslib_1.__decorate([
    Component({
        selector: 'app-header',
        templateUrl: './header.component.html',
        styleUrls: ['./header.component.scss']
    })
], HeaderComponent);
export { HeaderComponent };
//# sourceMappingURL=header.component.js.map