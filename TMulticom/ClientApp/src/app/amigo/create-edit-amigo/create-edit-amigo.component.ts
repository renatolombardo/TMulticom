import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Amigo } from '../../models/amigo';
import { AmigoService } from '../../services/amigo.service';

@Component({
  selector: 'app-create-edit-amigo',
  templateUrl: './create-edit-amigo.component.html',
  styleUrls: ['./create-edit-amigo.component.css']
})
export class CreateEditAmigoComponent implements OnInit {

  public amigo: Amigo = new Amigo();
  public sucesso: boolean = false;
  private id: string;

  constructor(
    private activatedRoute: ActivatedRoute,
    private amigoService: AmigoService) { }

  ngOnInit() {
    this.id = this.activatedRoute.snapshot.params.id;
    if (this.id != null) {
      this.obterAmigo();
    }
  }

  public inserir() {
    this.amigoService.inserir(this.amigo).subscribe(() => {
      this.sucesso = true;
    });
  }

  public atualizar() {
    this.amigoService.atualizar(this.amigo).subscribe(() => {
      this.sucesso = true;
    });
  }

  public obterAmigo() {
    this.amigoService.obterPorId(this.id).subscribe(result => {
      this.amigo = result;
    });
  }

}
