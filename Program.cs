using ConsumindoApiUsuarios.Entities;
using ConsumindoApiUsuarios.Entities.Services;
using System.Text.RegularExpressions;

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
            if (usuarioEncontrado.Nome != null)
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
            Console.WriteLine("Agora vamos ver o seu endereço pelo CEP.");
            Console.ReadKey();

            // teste usando a API BrasilAPI
            Console.WriteLine("Digite seu CEP (apenas os dígitos):");
            var cep = (Console.ReadLine());

            EnderecoServices servicesEndereco = new EnderecoServices();

            Endereco enderecoEncontrado = await servicesEndereco.Integracao(cep);

            if (enderecoEncontrado.Cep != null)
            {
                Console.WriteLine("Endereço encontrado:");
                Console.WriteLine("CEP: " + Convert.ToUInt64(enderecoEncontrado.Cep).ToString(@"00000\-000"));
                Console.WriteLine("Logradouro: " + enderecoEncontrado.Street);
                Console.WriteLine("Bairro: " + enderecoEncontrado.Neighborhood);
                Console.WriteLine("Cidade: " + enderecoEncontrado.City);
                Console.WriteLine("UF: " + enderecoEncontrado.State);
            }
            else
            {
                Console.WriteLine("Endereço não encontrado.");
            }


        }
    }
}