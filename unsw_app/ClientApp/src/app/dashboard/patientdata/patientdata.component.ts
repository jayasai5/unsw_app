import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr' ;
import { Patient } from '../models/patient';
import { DashboardService } from '../dashboard.service';
import { error } from 'util';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-patientdata',
  templateUrl: './patientdata.component.html',
  styleUrls: ['./patientdata.component.css']
})
export class PatientdataComponent implements OnInit {
  private _hubConnection: HubConnection;
  patients: Patient[];
  occupation: string;
  constructor(private service: DashboardService, private messageService: MessageService) { }

  ngOnInit() {
    this.service.getPatients()
      .subscribe((patients: Patient[]) => {
        this.patients = patients;
        console.log(this.patients)
      }, error => {
        console.log(error);

      });
    this._hubConnection = new HubConnectionBuilder()
      .withUrl("http://localhost:49944/notify")
      .build();
    this._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    this._hubConnection.on('BroadcastMessage', (patientid: number, occupation: string) => {
      this.UpdatePatient(patientid, occupation);
    });
  }
  UpdatePatient(patientid,occupation) {
    for (let patient of this.patients) {
      if (patient.patientId == patientid) {
        patient.occupation = occupation;
        this.messageService.add({ severity: 'success', summary: patient.patientName + 'has moved to the' + patient.occupation });
      }
    }
  }
}
