namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa;
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            try
            {
                placa = Console.ReadLine().ToUpper();
                veiculos.Add(placa);
            }
            catch(Exception err)
            {
                throw new Exception("Erro: Problemas ao inserir o usuario no banco.\n" + err.Message);
            }
        }

        public void RemoverVeiculo()
        {
            string placa;
            int horas;
            decimal valorTotal = 0;
            Console.WriteLine("Digite a placa do veículo para remover: ");
            try
            {
                placa = Console.ReadLine();
                if (veiculos.Any(x => x == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                    horas = int.Parse(Console.ReadLine());
                    valorTotal = precoInicial + precoPorHora * horas;
                    veiculos.RemoveAt(veiculos.IndexOf(placa.ToUpper())); 
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            catch(Exception err)
            {
                throw new Exception("Erro: Valor inserido não válido.\n" + err.Message);
            }
            // Verifica se o veículo existe
           
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(var v in veiculos)
                {
                    Console.WriteLine($"Veículo de placa: {v.ToString()}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
