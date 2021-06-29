import { Component, OnInit } from '@angular/core';
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

  constructor(
    private router: Router,
    private jogoService: JogoService) {

  }

  public obterJogos() {

    this.jogoService.obterJogos().subscribe(retorno => {
      this.jogos = retorno;
      this.carregado = true;
    });

  }

  public excluirJogo(id: string) {
    if (confirm('Deseja excluir esse jogo?')) {
      this.jogoService.excluir(id).subscribe(() => {
        this.obterJogos();
      });
    }
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
    this.jogoService.devolver(id).subscribe(() => {
      this.obterJogos();
    });
  }

  ngOnInit() {
    this.obterJogos();
  }





}
