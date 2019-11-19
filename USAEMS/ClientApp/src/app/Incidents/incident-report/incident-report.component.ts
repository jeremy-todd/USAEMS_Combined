import { Component, OnInit } from '@angular/core';
import { IncidentServiceService } from 'src/app/Services/incident-service.service';
import { IIncident } from 'src/app/Interfaces/incident';

@Component({
  selector: 'app-incident-report',
  templateUrl: './incident-report.component.html',
  styleUrls: ['./incident-report.component.scss']
})
export class IncidentReportComponent implements OnInit {

  incidentList: IIncident[] = [];

  constructor(private IncidentService: IncidentServiceService) { }

  ngOnInit() {
    this.IncidentService.getAll().subscribe(data => (this.incidentList = data));
    console.log(this.incidentList);
  }

}
