import { Component, OnInit } from '@angular/core';
import { GameService } from './services/game.service';
import { CurrentPlayerStateView } from '../generic/models/current-player-state-view';
import { ROUTER_CONFIGURATION } from '@angular/router';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  constructor(private gameService: GameService) { }

  public model: CurrentPlayerStateView[];
  private isCanHit: boolean = true;
  private playerName: string = localStorage.getItem("Player");
  public player: CurrentPlayerStateView = new CurrentPlayerStateView();

  ngOnInit() {
    this.gameService.CurrentGame().subscribe((data: CurrentPlayerStateView[]) => {
      this.model = data;
    });
  }

  public Hit() {
    if (this.isCanHit) {
      this.gameService.Hit().subscribe((data: CurrentPlayerStateView[]) => {
        this.model = data;
        this.player = data.find(x => x.playerName == this.playerName);
        if (this.player.totalCount > 21) {
          this.Enough();
          document.getElementById("openModalButton").click();
        }
      });
    }
  }

  public Enough() {
    this.gameService.Enough().subscribe((data: CurrentPlayerStateView[]) => {
      this.model = data;
      //let dealerCount = data.find(x => x.playerName == "Dealer").totalCount;
      // for (let i of this.model) {
      //   if (i.playerName != "Dealer" && (i.totalCount < 22 && i.totalCount > dealerCount || dealerCount > 21)) {
      //     console.log(i.totalCount);
      //     i.isWin = true;
      //   } else {
      //     i.isWin = false;
      //   }
      // }
    });
    this.isCanHit = false;
  }

  public FinishRound() {
    this.gameService.FinishRound().subscribe((data: CurrentPlayerStateView[]) => {
      this.model = data;
    });
    this.isCanHit = true;
  }
}
