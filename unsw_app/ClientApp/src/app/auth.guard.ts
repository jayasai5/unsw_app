import { CanActivate, Router } from "@angular/router";
import { UserService } from "./shared/services/user.service";
import { Injectable } from "@angular/core";
@Injectable()
export class AuthGuard implements CanActivate{
  constructor(private user: UserService, private router: Router) { }
  canActivate() {
    if (!this.user.isLoggedIn()) {
      this.router.navigate(['/account/login']);
      return false;
    }
    return true;
  }
}
