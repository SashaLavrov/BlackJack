import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/internal/Subscription';
import { ActivatedRoute } from '@angular/router';
import { GameService } from '../../game/services/game.service';

@Component({
  selector: 'app-game-history-details',
  templateUrl: './game-history-details.component.html',
})
export class GameHistoryDetailsComponent implements OnInit {
  private id: number;
  private routeSubscription: Subscription;

  constructor(private route: ActivatedRoute, private gameService: GameService) {
    this.routeSubscription = route.params.subscribe(params=>this.id=params['id']);
   }

  model;

  ngOnInit() {
    this.gameService.GameDateils(this.id).subscribe((data) => {
      this.model = data;
    })
  }

}
