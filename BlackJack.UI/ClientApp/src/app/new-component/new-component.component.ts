import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-new-component',
  templateUrl: './new-component.component.html',
  styleUrls: ['./new-component.component.css']
})
export class NewComponentComponent implements OnInit {
  message: string;

  isCollapsed: boolean = true;

  textVar : string = "hello world!";

  visibility: boolean = true;

  toggle(){
    this.visibility = !this.visibility;
  }

  constructor() { 
    setInterval(() => {
      this.message = new Date().toLocaleTimeString();
    }, 1000)
  }

  toggleCollapse(){
    this.isCollapsed = !this.isCollapsed;
  }

  ngOnInit() {
  }

}
