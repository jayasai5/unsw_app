import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RootComponent } from './root/root.component';
import { RouterModule } from '@angular/router';
import { AuthGuard } from '../auth.guard';
import { SharedModule } from '../shared/modules/shared.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: 'dashboard',
        component: RootComponent,
        canActivate: [AuthGuard],
        children: [
          { path: '', component: HomeComponent },
          { path: 'home', component: HomeComponent }
        ]
      }
    ])
  ],
  declarations: [HomeComponent, RootComponent],
  providers: [AuthGuard]
})
export class DashboardModule { }
