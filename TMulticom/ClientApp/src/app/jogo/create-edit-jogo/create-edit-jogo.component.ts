import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Jogo } from '../../models/jogo';

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
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.id = this.activatedRoute.snapshot.params.id;
    if (this.id != null) {
      this.obterJogo();
    }
  }

  public inserir() {
    this.http.post<Jogo>(this.baseUrl + 'jogo', this.jogo).subscribe(result => {
      this.sucesso = true;
    },
      error => console.error(error));
  }

  public atualizar() {
    this.http.put<Jogo>(this.baseUrl + 'jogo', this.jogo).subscribe(result => {
      this.sucesso = true;
    },
      error => console.error(error));
  }

  public obterJogo() {
    this.http.get<Jogo>(this.baseUrl + 'jogo/' + this.id).subscribe(result => {
      this.jogo = result;
      console.log(this.jogo);
    },
      error => console.error(error));
  }

}
