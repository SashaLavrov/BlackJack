import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { GameService } from '../../shared/serveces/gameservices/game.service'

@Component({
  selector: 'app-game-history',
  templateUrl: './game-history.component.html',
})
export class GameHistoryComponent implements OnInit {

  constructor(private http: HttpClient, private gameService: GameService) { }

  myData: gamesView[];

  ngOnInit() {
    this.gameService.getAllGamestory().subscribe((data: gamesView[]) => {
      this.myData = data;
    });
  }
}

export class gamesView {
  gameId: number;
  gameDate: Date;
}
