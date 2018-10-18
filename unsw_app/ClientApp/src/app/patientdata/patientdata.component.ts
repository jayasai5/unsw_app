import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr' ;

@Component({
  selector: 'app-patientdata',
  templateUrl: './patientdata.component.html',
  styleUrls: ['./patientdata.component.css']
})
export class PatientdataComponent implements OnInit {
  private _hubConnection: HubConnection;
  occupation: string ;
  constructor() { }

  ngOnInit() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:44347/notify")
      .build();
    this._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    this._hubConnection.on('BroadcastMessage', (patientid: number, occupation: string) => {
      this.occupation = occupation
    });
  }

}
