import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(private http: HttpClient) { }

  private Url: string = environment.API_URL;

  public SatrtNewGame(BotsCount: number, PlayerName: string) {
    return this.http.post<any>(this.Url + "/HomeAPI/startgame", { BotsCount, PlayerName });
  }

  public CurrentGame() {
    return this.http.get(this.Url + "/GameAPI/index");
  }

  public Hit() {
    return this.http.get(this.Url + "/GameAPI/Hit");
  }

  public Enough() {
    return this.http.get(this.Url + "/GameAPI/Enough");
  }

  public FinishRound() {
    return this.http.get(this.Url + "/GameAPI/FinishRound");
  }

  public GameDateils(id: number) {
    return this.http.get(this.Url + "/GameAPI/gamedateils/" + id);
  }

  public GetAllGamestory() {
    return this.http.get(this.Url + "/GameAPI/getallgamestory");
  }
}
