import { Component } from '@angular/core';
import { AuthenticationService } from '../authorization/authservices/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  //currentUser = this.authenticationService.currentUserValue;
  check : boolean = false;

 constructor(private authenticationService: AuthenticationService){ }

  isLogin() : boolean {
    if(this.authenticationService.currentUserValue){
      return true;
    }
    return false;
  }

  Logout(){
    this.authenticationService.logout();
  }
        

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
