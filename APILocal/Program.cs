using Refit;
using System;
using System.Threading.Tasks;

namespace APILocal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepCliente = RestService.For<APIService>("http://viacep.com.br");
                Console.WriteLine("Informe seu CEP: ");
                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando Informações do CEP " + cepInformado);


                var address = await cepCliente.GetAddressAsync(cepInformado);

                Console.WriteLine($"\nLogradouro:{address.logradouro},\nBairro:{address.bairro},\nLocalidade:{address.localidade},\nDDD:{address.ddd}");

            }
            catch (Exception e)
            {

                Console.WriteLine("Erro na Consulta de CEP." + e.Message);
            }
        }
    }
}
