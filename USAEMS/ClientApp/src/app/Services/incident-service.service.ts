import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IIncident } from '../Interfaces/incident';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IncidentServiceService {
  
  constructor(private http: HttpClient) {  }

  private _url: string = "https://localhost:5001/api/incidents";

  //Get all Incidents
  getAll(): Observable<IIncident[]> {
    return this.http.get<IIncident[]>(this._url);
  }


}
