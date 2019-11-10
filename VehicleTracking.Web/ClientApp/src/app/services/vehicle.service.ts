import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class VehicleService {
    _httpService: HttpClient;
    _apiURL: string;

    constructor(httpService: HttpClient, @Inject('Gateway_URL') apiURL: string) {
        this._httpService = httpService;
        this._apiURL = apiURL;
    }

    getVehicles(customerId): any {
        return this._httpService.get<any>(this._apiURL + "/api/vehicle/" + customerId);
    }

    getVehicleStatus(vehicleId): any {
        return this._httpService.get<any>(this._apiURL + "/api/vehiclestatus/" + vehicleId);
    }

}

export interface Vehicle {
    id: number;
    vehicleNumber: string;
    regNumbr: string;
    status: string;

}

