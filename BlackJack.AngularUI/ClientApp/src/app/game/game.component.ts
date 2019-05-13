import { Component, OnInit } from '@angular/core';
import { GameService } from '../_services/game/game.service'
import { CurrentPlayerStateView } from '../_models/current-player-state-view'

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  constructor(private gameService: GameService) { }

  model : CurrentPlayerStateView[];
  isShowDealerCards = false;
  isCanHit : boolean = true;

  ngOnInit() {
    this.gameService.CurrentGame().subscribe((data: CurrentPlayerStateView[]) => {
      this.model = data;
    });
  }

  Hit(){
    if(this.isCanHit){
      this.gameService.Hit().subscribe((data: CurrentPlayerStateView[]) => {
        this.model = data;
      });
    }
  }

  Enough(){
    this.gameService.Enough().subscribe((data: CurrentPlayerStateView[]) => {
       this.model = data;
    });

    this.isCanHit = false;
  }

  FinishRound(){
    this.gameService.FinishRound().subscribe((data: CurrentPlayerStateView[]) => {
      this.model = data;
    });
    this.isCanHit = true;
  }
}
