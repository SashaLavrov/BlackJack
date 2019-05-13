import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators} from '@angular/forms';
import { GameService } from '../../game/services/game.service';
import { first } from 'rxjs/operators';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
  startGameForm: FormGroup= this.formBuilder.group({
    playerName: ['', Validators.required],
    botCount: ['', Validators.required]
  });

  loading = false;
  submitted = false;
  error = '';

  constructor(private router:Router, private formBuilder: FormBuilder, private gameService: GameService) { }

  get f() { return this.startGameForm.controls; }

  ngOnInit() {

  }

  public onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.startGameForm.invalid) {
        return;
    }

    this.loading = true;
    this.gameService.SatrtNewGame(this.f.botCount.value, this.f.playerName.value)
        .pipe(first())
        .subscribe(
            data => {
              this.router.navigate(["/game"]);
            },
            error => {
                this.error = error;
                this.loading = false;
            });
  }
}