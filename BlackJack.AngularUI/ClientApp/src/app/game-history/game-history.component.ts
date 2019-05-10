import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-game-history',
  templateUrl: './game-history.component.html',
})
export class GameHistoryComponent implements OnInit {

  constructor(private http: HttpClient) { }

  myData: gamesView[];

  ngOnInit() {
    this.http.get("https://localhost:44378/api/GameAPI/getallgamestory").subscribe((data: gamesView[]) => {
      this.myData = data;
    });
  }
}

export class gamesView {
  gameId: number;
  gameDate: Date;
}
