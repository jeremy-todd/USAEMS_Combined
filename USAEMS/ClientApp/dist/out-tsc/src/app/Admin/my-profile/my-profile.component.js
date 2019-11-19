import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let MyProfileComponent = class MyProfileComponent {
    constructor(AuthService, formBuilder) {
        this.AuthService = AuthService;
        this.formBuilder = formBuilder;
        this.user = {
            id: "",
            firstName: "",
            lastName: "",
            securityQuestion: 0,
            securityAnswer: "",
            email: "",
            phoneNumber: "",
            carrierId: 0,
            employerId: 0,
            student: false,
            technical: false,
            active: false
        };
    }
    ngOnInit() {
        this.AuthService.currentUser.subscribe((currentUser) => {
            this.myProfileForm = this.formBuilder.group({
                firstName: currentUser.user.firstName,
                lastName: currentUser.user.lastName,
                securityQuestion: currentUser.user.securityQuestion,
                securityAnswer: currentUser.user.securityAnswer,
                email: currentUser.user.email,
                cellPhone: currentUser.user.phoneNumber,
                cellCarrier: currentUser.user.carrierId,
                employer: currentUser.user.employerId,
                student: currentUser.user.student,
                technical: currentUser.user.technical,
                active: currentUser.user.active
            });
        });
    }
};
MyProfileComponent = tslib_1.__decorate([
    Component({
        selector: 'app-my-profile',
        templateUrl: './my-profile.component.html',
        styleUrls: ['./my-profile.component.scss']
    })
], MyProfileComponent);
export { MyProfileComponent };
//# sourceMappingURL=my-profile.component.js.map