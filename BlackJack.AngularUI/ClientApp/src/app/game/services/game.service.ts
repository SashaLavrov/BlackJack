import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { CurrentPlayerStateView } from '../../generic/models/current-player-state-view';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(private http: HttpClient) { }

  public SatrtNewGame(BotsCount: number, PlayerName: string) {
    return this.http.post<any>("https://localhost:44356/api/HomeAPI/startgame", { BotsCount, PlayerName });
  }

  public CurrentGame() {
    return this.http.get("https://localhost:44356/api/GameAPI/index");
  }

  public Hit() {
    return this.http.get("https://localhost:44356/api/GameAPI/Hit");
  }

  public Enough() {
    return this.http.get("https://localhost:44356/api/GameAPI/Enough");
  }

  public FinishRound() {
    return this.http.get("https://localhost:44356/api/GameAPI/FinishRound");
  }

  public GameDateils(id: number) {
    return this.http.get("https://localhost:44356/api/GameAPI/gamedateils/" + id);
  }

  public GetAllGamestory() {
    return this.http.get("https://localhost:44356/api/GameAPI/getallgamestory");
  }
}
