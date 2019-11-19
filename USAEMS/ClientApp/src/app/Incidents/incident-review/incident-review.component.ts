import { Component, OnInit } from '@angular/core';
import { IIncident } from 'src/app/Interfaces/incident';
import { IncidentServiceService } from 'src/app/Services/incident-service.service';

@Component({
  selector: 'app-incident-review',
  templateUrl: './incident-review.component.html',
  styleUrls: ['./incident-review.component.scss']
})
export class IncidentReviewComponent implements OnInit {

  incidentList: IIncident[] = [];

  constructor(private IncidentService: IncidentServiceService) { }

  ngOnInit() {
    this.IncidentService.getAll().subscribe(data => (this.incidentList = data));
    console.log(this.incidentList);
  }

}
