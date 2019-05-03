import { Component } from '@angular/core';
import { NewService } from './new.service';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private http: HttpClient) {
    
  }

  myMethod(){
    this.http.get('https://localhost:44378/api/AccountAPI/test')
    .subscribe((response) => {
        console.log(response);
    });
  }
}
