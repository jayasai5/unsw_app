import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UserService } from '../shared/services/user.service';
import { SharedModule } from '../shared/modules/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { BaseService } from '../shared/services/base.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    RouterModule.forChild([
      { path: 'register', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ])
  ],
  declarations: [
    LoginComponent,
    RegistrationComponent
  ],
  providers: [
    UserService
  ]
})
export class AccountModule { }
