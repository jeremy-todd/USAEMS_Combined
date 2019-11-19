import { Component, OnInit } from '@angular/core';
import { InnerSubscriber } from 'rxjs/internal/InnerSubscriber';
import { IUser } from '../../Interfaces/iuser';
import { AuthService } from "../../Services/auth-service.service";
import { UserServiceService } from 'src/app/Services/user-service.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit{

  constructor( private AuthService: AuthService, private UserService: UserServiceService ) { }

  ngOnInit() {
    this.AuthService.currentUser.subscribe(
      (currentUser) => {
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
      }
    )
  } 

  

  user: IUser = {
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
  }

  signOut() {
    this.AuthService.logout();
  }


}