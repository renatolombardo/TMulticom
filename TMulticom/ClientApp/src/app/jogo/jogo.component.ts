import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Jogo } from '../interfaces/jogo';

@Component({
  selector: 'app-jogo',
  templateUrl: './jogo.component.html',
  styleUrls: ['./jogo.component.css']
})
export class JogoComponent implements OnInit {

  public jogos: Jogo[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Jogo[]>(baseUrl + 'jogo').subscribe(result => {
      this.jogos = result;
      console.log(this.jogos);
    },
      error => console.error(error));
  }

  ngOnInit() {
  }

}
