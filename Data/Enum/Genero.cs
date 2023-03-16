using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoApiUsuarios.Data.Enum
{
    internal enum Genero
    {
        [Description("Masculino")]
        Masculino = 1,
        [Description("Feminino")]
        Feminino = 2,
        [Description("Não definido")]
        NãoDefinido = 3
    }
}
