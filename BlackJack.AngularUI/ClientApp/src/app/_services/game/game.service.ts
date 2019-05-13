import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { CurrentPlayerStateView } from '../../_models/current-player-state-view';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(private http: HttpClient) { }

  SatrtNewGame(BotsCount: number, PlayerName: string) {
    return this.http.post<any>("https://localhost:44378/api/HomeAPI/startgame", { BotsCount, PlayerName });
  }

  CurrentGame(){
    return this.http.get("https://localhost:44378/api/GameAPI/index");
  }

  Hit(){
    return this.http.get("https://localhost:44378/api/GameAPI/Hit");
  }

  Enough(){
    return this.http.get("https://localhost:44378/api/GameAPI/Enough");
  }

  FinishRound(){
    return this.http.get("https://localhost:44378/api/GameAPI/FinishRound");
  }

  GameDateils(id: number){
    return this.http.get("https://localhost:44378/api/GameAPI/gamedateils/" + id);
  }

  GetAllGamestory(){
    return this.http.get("https://localhost:44378/api/GameAPI/getallgamestory");
  }
}
