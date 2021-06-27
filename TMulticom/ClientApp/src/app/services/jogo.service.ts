import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Jogo } from '../models/jogo';

@Injectable({
  providedIn: 'root'
})
export class JogoService {

  public jogos: Jogo[];

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  public obterJogos(): Jogo[] {

    this.http.get<Jogo[]>(this.baseUrl + 'jogo').subscribe(result => {
      this.jogos = result;
      return this.jogos;
    },
      error => console.error(error));

    return null;
    
  }
}
