import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Jogo } from '../models/jogo';
import { JogoService } from '../services/jogo.service';

@Component({
  selector: 'app-jogo',
  templateUrl: './jogo.component.html',
  styleUrls: ['./jogo.component.css']
})
export class JogoComponent implements OnInit {

  public jogos: Jogo[];
  public carregado: boolean = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router, private jogoService: JogoService) {
    
  }

  public obterJogos() {

    //this.http.get<Jogo[]>(this.baseUrl + 'jogo').subscribe(result => {
    //  this.jogos = result;
    //  this.carregado = true;
    //},
    //  error => console.error(error));
    this.jogos = this.jogoService.obterJogos();

  }

  public excluirJogo(id: string) {
    this.http.delete<Jogo[]>(this.baseUrl + 'jogo/' + id).subscribe(result => {
      this.obterJogos();
    },
      error => console.error(error));
  }

  public inserirJogo() {
    this.router.navigateByUrl("jogo/inserir");
  }

  public editarJogo(id: string) {
    this.router.navigateByUrl("jogo/editar/" + id);
  }

  public emprestarJogo(id: string) {
    this.router.navigateByUrl("jogo/emprestar/" + id);
  }

  public devolverJogo(id: string) {
    this.http.post<string>(this.baseUrl + 'jogo/devolver/' + id, id).subscribe(result => {
      this.obterJogos();
    },
      error => console.error(error));
  }

  ngOnInit() {
    this.obterJogos();
  }



  

}
