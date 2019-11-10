import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CustomerService {
    _httpService: HttpClient;
    _apiURL: string;
   
    constructor(httpService: HttpClient, @Inject('Gateway_URL') apiURL: string) {
        this._httpService = httpService;
        this._apiURL = apiURL;
    }

    fillCustomerNames(): any {
        return this._httpService.get<any>(this._apiURL + "/api/customer");
    }



}

export interface Customer {
    customerId: number;
    customerName: string;
    
}

