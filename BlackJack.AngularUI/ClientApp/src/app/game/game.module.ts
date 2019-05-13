import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameComponent } from './game.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path: '', component: GameComponent}
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  declarations: [
    GameComponent,
  ]
})
export class GameModule { }
