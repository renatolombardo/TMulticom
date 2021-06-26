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

        public Jogo(string nome, DateTime? dataEmprestimo)
        {
            Nome = nome;
            DataEmprestimo = dataEmprestimo;
        }

        [Required]
        [MaxLength(MAX_NOME_JOGO_TAMANHO)]
        public string Nome { get; private set; }
        public DateTime? DataEmprestimo { get; private set; }

        [ForeignKey("AmigoId")]
        public Guid? AmigoId { get; private set; }

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

       






    }
}
