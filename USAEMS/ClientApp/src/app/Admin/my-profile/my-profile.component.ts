import { Component, OnInit } from '@angular/core';
import { IUser } from '../../Interfaces/iuser';
import {FormBuilder, FormGroup } from '@angular/forms';
import { AuthService } from "../../Services/auth-service.service";


@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent implements OnInit {

  myProfileForm: FormGroup;

  constructor( private AuthService: AuthService, private formBuilder: FormBuilder ) { }

  ngOnInit() {
    this.AuthService.currentUser.subscribe(
      (currentUser) => {
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
        })
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
    employerId: 0,
    student: false,
    technical: false,
    active: false
  }
}