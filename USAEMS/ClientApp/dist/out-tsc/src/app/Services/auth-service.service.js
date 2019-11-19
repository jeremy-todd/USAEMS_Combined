import * as tslib_1 from "tslib";
import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { map } from "rxjs/operators";
let AuthService = class AuthService {
    constructor(http, router) {
        this.http = http;
        this.router = router;
        this.currentUserSubject = new BehaviorSubject(JSON.parse(localStorage.getItem("currentUser")));
        this.currentUser = this.currentUserSubject.asObservable();
    }
    get currentUserValue() {
        return this.currentUserSubject.value;
    }
    login(email, password) {
        return this.http
            .post("https://localhost:5001/api/auth/login", { email: email, password: password })
            .pipe(map(user => {
            console.log(user);
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem("currentUser", JSON.stringify(user));
            this.currentUserSubject.next(user);
            return user;
        }));
    }
    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem("currentUser");
        this.currentUserSubject.next(null);
        this.router.navigateByUrl('/login');
    }
    register(user) {
        return this.http.post("https://localhost:5001/api/auth/login", user);
    }
};
AuthService = tslib_1.__decorate([
    Injectable({
        providedIn: "root"
    })
], AuthService);
export { AuthService };
//# sourceMappingURL=auth-service.service.js.map