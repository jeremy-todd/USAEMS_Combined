import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
let IncidentServiceService = class IncidentServiceService {
    constructor(http) {
        this.http = http;
        this._url = "https://localhost:5001/api/incidents";
    }
    //Get all Incidents
    getAll() {
        return this.http.get(this._url);
    }
};
IncidentServiceService = tslib_1.__decorate([
    Injectable({
        providedIn: 'root'
    })
], IncidentServiceService);
export { IncidentServiceService };
//# sourceMappingURL=incident-service.service.js.map