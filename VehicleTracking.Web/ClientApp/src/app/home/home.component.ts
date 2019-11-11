import { Component } from '@angular/core';
import { CustomerService, Customer } from '../services/customer-service.service';
import { VehicleService, Vehicle } from '../services/vehicle.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
    customers: Customer[];
    vehicleService: VehicleService;
    vehicles: Vehicle[];
    filteredVehicles: Vehicle[];
    constructor(customerService: CustomerService, vehicleService: VehicleService) {
        this.vehicleService = vehicleService;
        customerService.fillCustomerNames().subscribe(res => {
            this.customers = res.customerNames;
        });
       
    }

    search(customerId, status) {
        console.log(status);
        if (status == 0)
            status = 'Disconnected';
        else status = 'Connected';
       
        this.vehicleService.getVehicles(customerId).subscribe(res => {
            this.filteredVehicles = [];     
            this.vehicles = res.vehicles;
            this.vehicles.forEach((v,index) => {
                this.vehicleService.getVehicleStatus(v.id).subscribe(res => {

                    if (res.vehiclePingModel && res.vehiclePingModel.pingStatus != 0) {
                        v.status = 'Connected';
                    }
                    else v.status = 'Disconnected';

                    if (v.status === status) {
                       
                        this.filteredVehicles.push(v);
                    }
                });
            });
            

           
        });
    }
}
