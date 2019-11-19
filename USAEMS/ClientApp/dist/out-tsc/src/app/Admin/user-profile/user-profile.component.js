import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let UserProfileComponent = class UserProfileComponent {
    constructor(UserService) {
        this.UserService = UserService;
        this.userList = [];
    }
    ngOnInit() {
        this.UserService.getAll().subscribe(data => (this.userList = data));
        console.log("userList = " + this.userList);
    }
};
UserProfileComponent = tslib_1.__decorate([
    Component({
        selector: 'app-user-profile',
        templateUrl: './user-profile.component.html',
        styleUrls: ['./user-profile.component.scss']
    })
], UserProfileComponent);
export { UserProfileComponent };
//# sourceMappingURL=user-profile.component.js.map