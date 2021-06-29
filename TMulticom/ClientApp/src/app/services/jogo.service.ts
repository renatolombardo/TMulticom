import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Emprestimo } from '../models/emprestimo';
import { Jogo } from '../models/jogo';

@Injectable({
  providedIn: 'root'
})
export class JogoService {

  public jogos: Jogo[];

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  public obterJogos(): Observable<Jogo[]> {
    return this.http.get<Jogo[]>(this.baseUrl + 'jogo');    
  }

  public excluir(id: string): Observable<string> {
    return this.http.delete<string>(this.baseUrl + 'jogo/' + id);
  }

  public devolver(id: string): Observable<string> {
    return this.http.post<string>(this.baseUrl + 'jogo/devolver/' + id, id);
  }

  public inserir(jogo: Jogo): Observable<Jogo> {
    return this.http.post<Jogo>(this.baseUrl + 'jogo', jogo);
  }

  public atualizar(jogo: Jogo): Observable<Jogo> {
    return this.http.put<Jogo>(this.baseUrl + 'jogo', jogo);
  }

  public obterPorId(id: string): Observable<Jogo> {
    return this.http.get<Jogo>(this.baseUrl + 'jogo/' + id);
  }

  public emprestar(jogoId: string, amigoId: string): Observable<Emprestimo> {
    let emprestimo = new Emprestimo();
    emprestimo.amigoId = amigoId;
    emprestimo.jogoId = jogoId;

    return this.http.post<Emprestimo>(this.baseUrl + 'jogo/emprestar', emprestimo);
  }
}
