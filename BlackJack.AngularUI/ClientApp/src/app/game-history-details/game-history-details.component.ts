import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/internal/Subscription';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CurrentPlayerStateView } from '../_models/current-player-state-view'

@Component({
  selector: 'app-game-history-details',
  templateUrl: './game-history-details.component.html',
})
export class GameHistoryDetailsComponent implements OnInit {
  private id: number;
  private routeSubscription: Subscription;

  constructor(private route: ActivatedRoute, private http: HttpClient) {
    this.routeSubscription = route.params.subscribe(params=>this.id=params['id']);
   }

   model;

  ngOnInit() {
    this.http.get("https://localhost:44378/api/GameAPI/gamedateils/" + this.id).subscribe((data) => {
      this.model = data;
    })
  }

}
