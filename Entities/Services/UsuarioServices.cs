
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ConsumindoApiUsuarios.Entities.Services
{
    internal class UsuarioServices
    {
        //async, pois é uma api externa para buscar dados em outro servidor, isso pode demorar. Declaro como async e usa o await para que aguarde o retorno da requisição
        public async Task<Usuario> Integracao(int id)
        {
            // instaciando o objeto HttpClient para usarmos o método GetAsync para receber a URL de onde buscará os dados.
            HttpClient client = new HttpClient();

            // essa URL é de uma api minha que fiz para cadastrar usuarios. Algo bem simples, estou aprendendo ainda. É o projeto CadastroUsuarios no GitHub
            var response = await client.GetAsync($"https://localhost:7051/api/CadastroUsuario/{id}");

            var jsonString = await response.Content.ReadAsStringAsync();

            // Método DeserializeObject vai receber uma string em JSON e transformar para os atributos do meu objeto Usuario
            var jsonObject = JsonConvert.DeserializeObject<Usuario>(jsonString);


            // fazendo a verificação de retorno. Caso o ID informado exista, ele me retorno o jsonObject(Usuario com os atributos), caso não exista estou tratando no else e instaciando um novo objeto Usuario.
            if (jsonObject != null)
            {
                return jsonObject;
            }
            else
            {
                return new Usuario
                { 
                    Verificacao = true
                };

            }
        }
    }
}

