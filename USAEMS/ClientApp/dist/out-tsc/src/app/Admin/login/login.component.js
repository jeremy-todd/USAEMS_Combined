import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
let LoginComponent = class LoginComponent {
    constructor(formBuilder, AuthService, Router, route) {
        this.formBuilder = formBuilder;
        this.AuthService = AuthService;
        this.Router = Router;
        this.route = route;
        this.submitted = false;
        this.error = '';
        if (this.AuthService.currentUserValue) {
            //this.Router.navigateByUrl("/");
        }
    }
    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            email: ['', Validators.required],
            password: ['', Validators.required]
        });
        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }
    // covenience getter for easy access to form fields
    get f() { return this.loginForm.controls; }
    onSubmit(loginData) {
        this.submitted = true;
        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }
        console.warn("Submitted", loginData);
        this.AuthService.login(this.f.email.value, this.f.password.value)
            .pipe(first())
            .subscribe(data => {
            this.Router.navigate([this.returnUrl]);
        }, error => {
            this.error = error;
            this.Router.navigate(['/login'], { queryParams: { error: true } });
            console.log(error);
        });
    }
};
LoginComponent = tslib_1.__decorate([
    Component({
        selector: 'app-login',
        templateUrl: './login.component.html',
        styleUrls: ['./login.component.scss']
    })
], LoginComponent);
export { LoginComponent };
//# sourceMappingURL=login.component.js.map