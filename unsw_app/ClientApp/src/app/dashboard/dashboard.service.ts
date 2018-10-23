import { Injectable } from '@angular/core';
import { BaseService } from '../shared/services/base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfigService } from '../shared/utils/config.service';
import { Observable } from 'rxjs/Observable';
import { Medicaluser } from './models/medicaluser';
import { Patient } from './models/patient';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer ' + localStorage.getItem('auth_token')
  })
};
@Injectable()
export class DashboardService extends BaseService {
  baseUrl: string = ''; 
  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  getAllMedicalUsers(): Observable<Medicaluser[]> {
    
    return this.http.get<{ users: Medicaluser[] }>(this.baseUrl + '/admin/medicalusers', httpOptions)
      .map(response => response.users).catch(this.handleError);
  }
  editUsers(users: Medicaluser[]): Observable<Medicaluser[]> {
    return this.http.post<{ users: Medicaluser[] }>(this.baseUrl + '/admin/editusers', users , httpOptions)
      .map(response => response.users).catch(this.handleError);
  }
  getPatients(): Observable<Patient[]> {
    return this.http.get<{ patients: Patient[] }>(this.baseUrl + '/message/patients', httpOptions)
      .map(response => response.patients).catch(this.handleError);
  }
}
