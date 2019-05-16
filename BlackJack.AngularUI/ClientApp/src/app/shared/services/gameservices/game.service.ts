import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(private http: HttpClient) { }

  private Url: string = environment.API_URL;

  public SatrtNewGame(botsCount: number, playerName: string) {
    return this.http.post<any>(this.Url + "/HomeAPI/startgame", { botsCount, playerName });
  }

  public currentGame() {
    return this.http.get(this.Url + "/GameAPI/index");
  }

  public Hit() {
    return this.http.get(this.Url + "/GameAPI/Hit");
  }

  public enough() {
    return this.http.get(this.Url + "/GameAPI/Enough");
  }

  public finishRound() {
    return this.http.get(this.Url + "/GameAPI/FinishRound");
  }

  public gameDateils(id: number) {
    return this.http.get(this.Url + "/GameAPI/gamedateils/" + id);
  }

  public getAllGamestory() {
    return this.http.get(this.Url + "/GameAPI/getallgamestory");
  }
}
