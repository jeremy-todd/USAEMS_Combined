import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let IncidentReportComponent = class IncidentReportComponent {
    constructor(IncidentService) {
        this.IncidentService = IncidentService;
        this.incidentList = [];
    }
    ngOnInit() {
        this.IncidentService.getAll().subscribe(data => (this.incidentList = data));
        console.log(this.incidentList);
    }
};
IncidentReportComponent = tslib_1.__decorate([
    Component({
        selector: 'app-incident-report',
        templateUrl: './incident-report.component.html',
        styleUrls: ['./incident-report.component.scss']
    })
], IncidentReportComponent);
export { IncidentReportComponent };
//# sourceMappingURL=incident-report.component.js.map