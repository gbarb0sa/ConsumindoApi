﻿
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ConsumindoApiUsuarios.Entities.Services
{
    internal class EnderecoServices
    {
        //async, pois é uma api externa para buscar dados em outro servidor, isso pode demorar. Declaro como async e usa o await para que aguarde o retorno da requisição
        public async Task<Endereco> Integracao(string cep)
        {
            // instaciando o objeto HttpClient para usarmos o método GetAsync para receber a URL de onde buscará os dados.
            HttpClient client = new HttpClient();

            // essa URL é de uma api minha que fiz para cadastrar usuarios. Algo bem simples, estou aprendendo ainda. É o projeto CadastroUsuarios no GitHub
            var response = await client.GetAsync($"https://brasilapi.com.br/api/cep/v1/{cep}");

            var jsonString = await response.Content.ReadAsStringAsync();

            // Método DeserializeObject vai receber uma string em JSON e transformar para os atributos do meu objeto Usuario
            var jsonObject = JsonConvert.DeserializeObject<Endereco>(jsonString);


            // fazendo a verificação de retorno. Caso o ID informado exista, ele me retorno o jsonObject(Usuario com os atributos), caso não exista estou tratando no else e instaciando um novo objeto Usuario.
            if (jsonObject != null)
            {
                return jsonObject;
            }
            else
            {
                return new Endereco
                { 
                    Verificacao = true
                };

            }
        }
    }
}

