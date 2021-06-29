import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Jogo } from '../../models/jogo';
import { JogoService } from '../../services/jogo.service';

@Component({
  selector: 'app-create-edit-jogo',
  templateUrl: './create-edit-jogo.component.html',
  styleUrls: ['./create-edit-jogo.component.css']
})
export class CreateEditJogoComponent implements OnInit {

  public jogo: Jogo = new Jogo();
  public sucesso: boolean = false;
  private id: string;

  constructor(
    private activatedRoute: ActivatedRoute,
    private jogoService: JogoService) { }

  ngOnInit() {
    this.id = this.activatedRoute.snapshot.params.id;
    if (this.id != null) {
      this.obterJogo();
    }
  }

  public inserir() {
    this.jogoService.inserir(this.jogo).subscribe(() => {
      this.sucesso = true;
    });
  }

  public atualizar() {
    this.jogoService.atualizar(this.jogo).subscribe(() => {
      this.sucesso = true;
    });
  }

  public obterJogo() {
    this.jogoService.obterPorId(this.id).subscribe(result => {
      this.jogo = result;
    });
  }

}
