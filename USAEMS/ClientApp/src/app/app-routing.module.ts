import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserProfileComponent } from './Admin/user-profile/user-profile.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './Admin/register/register.component';
import { MyProfileComponent } from './Admin/my-profile/my-profile.component';
import { IncidentsAdminComponent } from './Incidents/incidents-admin/incidents-admin.component';
import { IncidentReportComponent } from './Incidents/incident-report/incident-report.component';
import { EventAdminComponent } from './Events/event-admin/event-admin.component';
import { IncidentReviewComponent } from './Incidents/incident-review/incident-review.component';
import { LoginComponent } from './Admin/login/login.component';


const routes: Routes = [
  { path:"", component: HomeComponent },
  { path:"home", component: HomeComponent},
  { path:"userProfile", component: UserProfileComponent },
  { path:"profile", component: MyProfileComponent },
  { path:"register", component: RegisterComponent },
  { path:"incidents", component: IncidentsAdminComponent},
  { path:"incidentReport", component: IncidentReportComponent },
  { path:"incidentsReview", component: IncidentReviewComponent },
  { path:"events", component: EventAdminComponent },
  { path:"login", component:LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
