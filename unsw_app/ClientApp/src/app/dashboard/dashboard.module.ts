import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RootComponent } from './root/root.component';
import { RouterModule } from '@angular/router';
import { AuthGuard } from '../auth.guard';
import { SharedModule } from '../shared/modules/shared.module';
import { FormsModule } from '@angular/forms';
import { UserService } from '../shared/services/user.service';
import { ApproveusersComponent } from './approveusers/approveusers.component';
import { DashboardService } from './dashboard.service';
import { HttpClientModule } from '@angular/common/http';
import { MessageService } from 'primeng/api';
import { PatientdataComponent } from './patientdata/patientdata.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forChild([
      {
        path: 'dashboard',
        component: RootComponent,
        canActivate: [AuthGuard],
        children: [
          { path: '', component: HomeComponent },
          { path: 'home', component: HomeComponent },
          { path: 'approveusers', component: ApproveusersComponent },
          { path: 'patientdata', component: PatientdataComponent }
        ]
      }
    ])
  ],
  declarations: [HomeComponent, RootComponent, ApproveusersComponent, PatientdataComponent],
  providers: [AuthGuard, UserService, DashboardService, MessageService]
})
export class DashboardModule { }
