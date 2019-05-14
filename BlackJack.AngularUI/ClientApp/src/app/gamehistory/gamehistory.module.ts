import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameHistoryComponent } from '../gamehistory/game-history/game-history.component';
import { GameHistoryDetailsComponent } from '../gamehistory/game-history-details/game-history-details.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: GameHistoryComponent },
  { path: 'details/:id', component: GameHistoryDetailsComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  declarations: [
    GameHistoryComponent,
    GameHistoryDetailsComponent
  ]
})
export class GamehistoryModule { }
