import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './authorization/login/login.component';
import { JwtInterceptor } from '../app/_helpers/jwt-interceptor';
import { AuthGuard } from './_guards/auth.guard';
import { RegisterComponent } from './authorization/register/register.component';
import { ErrorInterceptor } from './_helpers/error-interceptor';
import { GameHistoryComponent } from './game-history/game-history.component';
import { GameHistoryDetailsComponent } from './game-history-details/game-history-details.component';
import { GameComponent } from './game/game.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    GameHistoryComponent,
    GameHistoryDetailsComponent,
    GameComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'gamehistory/details/:id',component: GameHistoryDetailsComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      //{ path: 'authorization', loadChildren: './authorization/authorization.module#AuthorizationModule'},
      { path: 'gamehistory', component: GameHistoryComponent },
      { path: 'game', component: GameComponent },
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
