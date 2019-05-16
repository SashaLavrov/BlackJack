import { Component, OnInit } from '@angular/core';
import { GameService } from '../shared/serveces/gameservices/game.service';
import { CurrentPlayerStateView } from '../shared/models/current-player-state-view';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  constructor(private gameService: GameService) { }
 
  private maxScore: number = 21;
  public model: CurrentPlayerStateView[];
  private isCanHit: boolean = true;
  private playerName: string = localStorage.getItem("Player");
  public player: CurrentPlayerStateView = new CurrentPlayerStateView();
  public dealer: CurrentPlayerStateView = new CurrentPlayerStateView();
  public isPlayerWin: boolean = false;

  ngOnInit() {
    this.gameService.currentGame().subscribe((data: CurrentPlayerStateView[]) => {
      this.model = data;
    });
  }

  public Hit() {
    if (this.isCanHit) {
      this.gameService.Hit().subscribe((data: CurrentPlayerStateView[]) => {
        this.model = data;
        this.player = data.find(x => x.playerName == this.playerName);
        this.dealer = data.find(x => x.playerName == "Dealer");
        if (this.player.totalCount > this.maxScore) {
          this.Enough();
        }
      });
    }
  }

  public Enough() {
    this.gameService.enough().subscribe((data: CurrentPlayerStateView[]) => {
      this.model = data;
      this.player = data.find(x => x.playerName == this.playerName);
      this.dealer = data.find(x => x.playerName == "Dealer");

      console.log(this.dealer.totalCount);
      if(this.player.totalCount > this.maxScore){
        document.getElementById("overScoreButton").click();
      }
      else if(this.dealer.totalCount < this.player.totalCount || this.dealer.totalCount > 21){
        this.isPlayerWin = true;
        document.getElementById("enoughButton").click();
      }else{
        document.getElementById("enoughButton").click();
        this.isPlayerWin = false;
      }
    });
    this.isCanHit = false;
  }

  public FinishRound() {
    this.gameService.finishRound().subscribe((data: CurrentPlayerStateView[]) => {
      this.model = data;
    });
    this.isCanHit = true;
  }
}
