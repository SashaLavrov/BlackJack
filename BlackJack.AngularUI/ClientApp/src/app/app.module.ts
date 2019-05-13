import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './generic/nav-menu/nav-menu.component';
import { HomeComponent } from './generic/home/home.component';
import { JwtInterceptor } from "../app/generic/helpers/jwt-interceptor";
import { ErrorInterceptor } from '../app/generic/helpers/error-interceptor';
import { AuthGuard } from './generic/guards/auth.guard';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, canActivate: [AuthGuard]},
      { path: 'authorization', loadChildren: './authorization/authorization.module#AuthorizationModule' },
      { path: 'gamehistory', loadChildren: './gamehistory/gamehistory.module#GamehistoryModule', canActivate: [AuthGuard]},
      { path: 'game', loadChildren: './game/game.module#GameModule', canActivate: [AuthGuard]},
      { path: '**', redirectTo: '' }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
