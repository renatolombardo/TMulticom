import { Jogo } from "./jogo";

export interface Amigo {
  id: string;
  nome: string;
  jogos: Jogo[];
}
