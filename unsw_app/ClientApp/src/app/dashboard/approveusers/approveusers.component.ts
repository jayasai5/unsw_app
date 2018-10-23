import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../dashboard.service';
import { Medicaluser } from '../models/medicaluser';
import { error } from 'protractor';
import { userInfo } from 'os';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-approveusers',
  templateUrl: './approveusers.component.html',
  styleUrls: ['./approveusers.component.css']
})
export class ApproveusersComponent implements OnInit {
  public users: Medicaluser[];
  constructor(private service: DashboardService, private messageService: MessageService) { }

  ngOnInit() {
    this.service.getAllMedicalUsers()
      .subscribe((users: Medicaluser[]) => {
        this.users = users;
      }, error => {
        console.log(error);
      })
  }
  EditUsers() {
    this.service.editUsers(this.users)
      .subscribe((users: Medicaluser[]) => {
        this.users = users;
        this.messageService.add({ severity: 'success', summary:'Successfully Updated' });
      }, error => {
        console.log(error);
      })
  }
}
