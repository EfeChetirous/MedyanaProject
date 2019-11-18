import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-equipment',
    templateUrl: './equipment.component.html'
})
export class EquipmentDataComponent {
    public equipments: Equipment[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<Equipment[]>(baseUrl + 'api/Equipment/GetAllEquipments').subscribe(result => {

            this.equipments = result.root;
        }, error => console.error(error));
    }
}

interface Equipment {
    id: string;
    clinicId: string;
    clinicName: string;    
    name: string;
    provideDate: Date;
    countInfo: string;
    unitPrice: string;
    usageRate: string;
}
