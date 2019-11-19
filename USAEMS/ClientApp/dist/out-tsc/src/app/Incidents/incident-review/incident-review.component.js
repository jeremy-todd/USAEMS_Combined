import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let IncidentReviewComponent = class IncidentReviewComponent {
    constructor(IncidentService) {
        this.IncidentService = IncidentService;
        this.incidentList = [];
    }
    ngOnInit() {
        this.IncidentService.getAll().subscribe(data => (this.incidentList = data));
        console.log(this.incidentList);
    }
};
IncidentReviewComponent = tslib_1.__decorate([
    Component({
        selector: 'app-incident-review',
        templateUrl: './incident-review.component.html',
        styleUrls: ['./incident-review.component.scss']
    })
], IncidentReviewComponent);
export { IncidentReviewComponent };
//# sourceMappingURL=incident-review.component.js.map