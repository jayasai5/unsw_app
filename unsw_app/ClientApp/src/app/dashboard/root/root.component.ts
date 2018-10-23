import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/services/user.service';


@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css']
})
export class RootComponent implements OnInit {
  admin: boolean = false;
  access: string = localStorage.getItem('auth_access');
  constructor(private user: UserService) {
    if (this.access == "admin_access")
      this.admin = true;
  }

  ngOnInit() {
  }

}
