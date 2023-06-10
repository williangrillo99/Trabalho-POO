using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.DataTransfer.Usuarios.Request
{
    public class LoginRequest
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
    }
}
