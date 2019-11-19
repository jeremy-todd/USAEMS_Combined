import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
let UserServiceService = class UserServiceService {
    constructor(http) {
        this.http = http;
        this._url = "https://localhost:5001/api/AppUsers";
    }
    ngOnInit() { }
    //Get all Users
    getAll() {
        return this.http.get(this._url);
    }
};
UserServiceService = tslib_1.__decorate([
    Injectable({
        providedIn: 'root'
    })
], UserServiceService);
export { UserServiceService };
//# sourceMappingURL=user-service.service.js.map