import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Amigo } from '../../models/amigo';
import { Jogo } from '../../models/jogo';
import { AmigoService } from '../../services/amigo.service';
import { JogoService } from '../../services/jogo.service';

@Component({
  selector: 'app-emprestar-jogo',
  templateUrl: './emprestar-jogo.component.html',
  styleUrls: ['./emprestar-jogo.component.css']
})
export class EmprestarJogoComponent implements OnInit {

  public amigos: Amigo[];
  public jogo: Jogo;
  public emprestado: boolean = false;
  private jogoId: string;
  private amigoId: string;
  public mensagemErro: string;

  constructor(
    private activatedRoute: ActivatedRoute,
    private amigoService: AmigoService,
    private jogoService: JogoService) {
  }
  ngOnInit() {
    this.jogoId = this.activatedRoute.snapshot.params.id;
    this.obterAmigos();
    this.jogoService.obterPorId(this.jogoId).subscribe(retorno => {
      this.jogo = retorno;
    });
  }

  public obterAmigos() {
    this.amigoService.obterAmigos().subscribe(retorno => {
      this.amigos = retorno;
    });
  }

  public emprestar() {
    console.log(this.jogoId, this.amigoId);
    this.jogoService.emprestar(this.jogoId, this.amigoId).subscribe(() => {
      this.emprestado = true;
    },
      err => {
        this.mensagemErro = err.error;
      });
  }

}
