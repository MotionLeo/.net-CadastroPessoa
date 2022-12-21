using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoas
{
    internal interface IPessoa
    {
        public int IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
    }
}
