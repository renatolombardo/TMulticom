import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Amigo } from '../models/amigo';
import { AmigoService } from '../services/amigo.service';

@Component({
  selector: 'app-amigo',
  templateUrl: './amigo.component.html',
  styleUrls: ['./amigo.component.css']
})
export class AmigoComponent implements OnInit {

  public amigos: Amigo[];
  public carregado: boolean = false;

  constructor(
    private router: Router,
    private amigoService: AmigoService) {
  }

  public obterAmigos() {

    this.amigoService.obterAmigos().subscribe(retorno => {
      this.amigos = retorno;
      this.carregado = true;
    });

  }

  public excluirAmigo(id: string) {
    if (confirm('Deseja excluir esse amigo?')) {
      this.amigoService.excluir(id).subscribe(() => {
        this.obterAmigos();
      });
    }
    
  }

  public inserirAmigo() {
    this.router.navigateByUrl("amigo/inserir");
  }

  public editarAmigo(id: string) {
    this.router.navigateByUrl("amigo/editar/" + id);
  }

  ngOnInit() {
    this.obterAmigos();
  }

}
