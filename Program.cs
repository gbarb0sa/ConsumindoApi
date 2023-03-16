using ConsumindoApiUsuarios.Entities;
using ConsumindoApiUsuarios.Entities.Services;

namespace ConsumindoApiUsuarios
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Digite o ID:");
            var id = int.Parse(Console.ReadLine());

            UsuarioServices services = new UsuarioServices();

            Usuario usuarioEncontrado = await services.Integracao(id);


            //tive que validar se algum dos atributos estava vindo vazio, pois a API que estou consumindo, que inclusive eu quem fiz, sempre me retorna algo, mesmo que vazio. Fazendo essa condicional abaixo ela não me apresenta os campos vazios.
            if(usuarioEncontrado.Nome != null)
            {
                Console.WriteLine("Usuario encontrado:");
                Console.WriteLine("Nome: " + usuarioEncontrado.Nome);
                Console.WriteLine("Email: " + usuarioEncontrado.Email);
                Console.WriteLine("Gênero: " + usuarioEncontrado.Genero);
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
            Console.ReadKey();
        }
    }
}