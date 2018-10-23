import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  admin: boolean = localStorage.getItem('auth_access')=="admin_access";
  constructor() { }

  ngOnInit() {
  }

}
