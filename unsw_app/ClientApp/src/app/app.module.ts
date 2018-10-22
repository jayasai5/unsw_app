import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {  HttpClientModule  } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PatientdataComponent } from './patientdata/patientdata.component';
import { DashboardModule } from './dashboard/dashboard.module';
import { AccountModule } from './account/account.module';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { ConfigService } from './shared/utils/config.service';

@NgModule({
  declarations: [
    AppComponent,
    FetchDataComponent,
    PatientdataComponent,
    HeaderComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    DashboardModule,
    AccountModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'account', loadChildren: 'app/account/account.module#AccountModule' }
    ])
  ],
  providers: [ConfigService],
  bootstrap: [AppComponent]
})
export class AppModule { }
