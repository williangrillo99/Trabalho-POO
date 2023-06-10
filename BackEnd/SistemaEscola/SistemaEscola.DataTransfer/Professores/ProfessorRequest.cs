using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.DataTransfer.Professores
{
    public class ProfessorRequest
    {
        public string Nome { get; set; }

        public string Senha { get; set; }  
        
        public int idTurma { get; set; }
      
    }
}
