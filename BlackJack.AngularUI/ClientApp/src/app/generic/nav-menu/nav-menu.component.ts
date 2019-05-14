import { Component } from '@angular/core';
import { AuthenticationService } from '../../authorization/authservices/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  check: boolean = false;

  constructor(private authenticationService: AuthenticationService) { }

  public isLogin(): boolean {
    if (this.authenticationService.currentUserValue) {
      return true;
    }
    return false;
  }

  public Logout() {
    this.authenticationService.logout();
  }


  public collapse() {
    this.isExpanded = false;
  }

  public toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
