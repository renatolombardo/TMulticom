using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMulticom.Domain.Models
{
    public class Jogo : Entity
    {
        public const int MAX_NOME_JOGO_TAMANHO = 255;

        public Jogo(string nome)
        {
            Nome = nome;
        }

        [Required]
        [MaxLength(MAX_NOME_JOGO_TAMANHO)]
        public string Nome { get; private set; }
        public DateTime? DataEmprestimo { get; private set; }

        public Guid? AmigoId { get; private set; }

        [ForeignKey("AmigoId")]
        public Amigo Amigo { get; set; }

        public void InformarEmprestimo(Guid amigoId)
        {
            DataEmprestimo = DateTime.Now;
            AmigoId = amigoId;
        }

        public void RemoverEmprestimo()
        {
            DataEmprestimo = null;
            AmigoId = null;
        }

        public void DefinirNome(string nome)
        {
            Nome = nome;
        }

       






    }
}
