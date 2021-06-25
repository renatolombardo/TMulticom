using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMulticom.Domain.Models
{
    public class Amigo : Entity
    {

        public const int MAX_NOME_AMIGO_TAMANHO = 255;

        private IList<Jogo> _jogos;

        public Amigo(string nome)
        {
            Nome = nome;
            _jogos = new List<Jogo>();
        }

        [Required]
        [MaxLength(MAX_NOME_AMIGO_TAMANHO)]
        public string Nome { get; private set; }

        //public IReadOnlyCollection<Jogo> Jogos { get => _jogos.ToArray(); }
        public virtual IList<Jogo> Jogos { get; set; }

        public void EmprestarJogo(Jogo jogo)
        {
            jogo.DataEmprestimo = DateTime.Now;
            _jogos.Add(jogo);
        }

        public void DevolverJogo(Jogo jogo)
        {
            jogo.DataEmprestimo = null;
            _jogos.Remove(jogo);
        }
    }
}
