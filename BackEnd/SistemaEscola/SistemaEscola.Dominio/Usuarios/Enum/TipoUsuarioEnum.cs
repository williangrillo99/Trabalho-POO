using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Usuarios.Enum
{
    public enum TipoUsuarioEnum
    {
        [Description("Aluno")]
        Aluno =  1,

        [Description("Professor")]
        Professor = 2,

        [Description("Admin")]
        Admin = 3,
    }
}
