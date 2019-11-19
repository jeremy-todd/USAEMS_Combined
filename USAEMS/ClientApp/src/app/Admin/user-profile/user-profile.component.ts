import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/Interfaces/iuser';
import { UserServiceService } from 'src/app/Services/user-service.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  
  userList: IUser[] = [];

  constructor(private UserService: UserServiceService) { }

  ngOnInit() {
    this.UserService.getAll().subscribe(data => (this.userList = data));
    console.log("userList = " + this.userList);
  }

}
