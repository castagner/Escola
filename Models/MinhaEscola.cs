using System;

namespace Escola.Models
{
    public class MinhaEscola
    {
        public int ID { get; set; }
        public string Nome  { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public int Quantidade_Professor { get; set; }
        public int Quantidade_Alunos { get; set; }
    }
}