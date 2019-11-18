import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-clinic',
    templateUrl: './clinic.component.html'
})
export class ClinicDataComponent {
    public clinics: Clinic[];
    //public _baseUrl: string;
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        //_baseUrl = baseUrl;
        http.get<Clinic[]>(baseUrl + 'api/Clinic/GetAllClinics').subscribe(result => {
            this.clinics = result.root;
        }, error => console.error(error));
    }
    public deleteClinic(id) {
        this.http.get(location.origin + '/api/Clinic/SoftDeleteClinicAsync/${id}').subscribe(result => {
            
        }, error => console.error(error));
    }
}
//export function getBaseUrl() {
//    return document.getElementsByTagName('base')[0].href;
//}
interface Clinic {
    id: string;
    name: string;
}
