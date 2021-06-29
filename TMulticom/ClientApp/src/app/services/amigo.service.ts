import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Amigo } from '../models/amigo';

@Injectable({
  providedIn: 'root'
})
export class AmigoService {
  public amigos: Amigo[];

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  public obterAmigos(): Observable<Amigo[]> {
    return this.http.get<Amigo[]>(this.baseUrl + 'amigo');
  }

  public excluir(id: string): Observable<string> {
    return this.http.delete<string>(this.baseUrl + 'amigo/' + id);
  }

  public inserir(amigo: Amigo): Observable<Amigo> {
    return this.http.post<Amigo>(this.baseUrl + 'amigo', amigo);
  }

  public atualizar(amigo: Amigo): Observable<Amigo> {
    return this.http.put<Amigo>(this.baseUrl + 'amigo', amigo);
  }

  public obterPorId(id: string): Observable<Amigo> {
    return this.http.get<Amigo>(this.baseUrl + 'amigo/' + id);
  }
}
