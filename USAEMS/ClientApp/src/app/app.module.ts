import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserProfileComponent } from './Admin/user-profile/user-profile.component';
import { IncidentsAdminComponent } from './Incidents/incidents-admin/incidents-admin.component';
import { IncidentReportComponent } from './Incidents/incident-report/incident-report.component';
import { IncidentReviewComponent } from './Incidents/incident-review/incident-review.component';
import { EventAdminComponent } from './Events/event-admin/event-admin.component';
import { HeaderComponent } from './Admin/header/header.component';
import { FooterComponent } from './Admin/footer/footer.component';
import { RegisterComponent } from './Admin/register/register.component';
import { HomeComponent } from './home/home.component';
import { MyProfileComponent } from './Admin/my-profile/my-profile.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './Admin/login/login.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './Helpers/jwt.interceptor';
import { ErrorInterceptor } from './Helpers/error.interceptor';
import { AuthService } from './Services/auth-service.service';

@NgModule({
  declarations: [
    AppComponent,
    UserProfileComponent,
    IncidentsAdminComponent,
    IncidentReportComponent,
    IncidentReviewComponent,
    EventAdminComponent,
    HeaderComponent,
    FooterComponent,
    RegisterComponent,
    HomeComponent,
    UserProfileComponent,
    MyProfileComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    
  ],
  providers: [
    AuthService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }