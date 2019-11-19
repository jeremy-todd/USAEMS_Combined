import { Injectable } from '@angular/core';
import { IUser } from '../Interfaces/iuser';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { IAuthResponse } from '../Interfaces/iauth-response';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  private userList: BehaviorSubject<IAuthResponse>;

  constructor( private http: HttpClient ) { }

  ngOnInit() { } 

  private _url: string = "https://localhost:5001/api/AppUsers";

  //Get all Users
  getAll(): Observable<IUser[]> {
    return this.http.get<IUser[]>(this._url);
  }
}
