using ConsumindoApiUsuarios.Data.Enum;
using System.Net.Sockets;

namespace ConsumindoApiUsuarios.Entities
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Genero? Genero { get; set; }

        public bool Verificacao = false;
    }
}
