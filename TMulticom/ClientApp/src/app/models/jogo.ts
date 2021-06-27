import { Amigo } from "./amigo";

export interface Jogo {
  id: string;
  nome: string;
  dataEmprestimo: Date;
  amigoId: string;
  amigo: Amigo;
}
