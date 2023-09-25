namespace cgp_appv02
{
    internal class Program
    {
        class Cliente
        {
            struct cliente
            {
                public string Nome;
                public string Morada;
                public int NIF;
                public int NIPC;
                public DateTime DataNascimento;
                public int Telefone;
                public string Nacionalidade;
                public decimal SaldoTotal;
            }

            static cliente CriarCliente(string Nome, string Morada, int NIF, int NIPC, DateTime DataNascimento, int Telefone, string Nacionalidade, int SaldoTotal)
            {
                cliente cliente;

                cliente.Nome = Nome;
                cliente.Morada = Morada;
                cliente.NIF = NIF;
                cliente.NIPC = NIPC;
                cliente.DataNascimento = DataNascimento;
                cliente.Telefone = Telefone;
                cliente.Nacionalidade = Nacionalidade;
                cliente.SaldoTotal = SaldoTotal;

                return cliente;
            }

            static cliente LerCliente()
            {
                cliente cliente;

                Console.WriteLine("Digite o Nome do Cliente: ");
                cliente.Nome = Console.ReadLine();
                Console.WriteLine("Digite a Morada do Cliente: ");
                cliente.Morada = Console.ReadLine();
                Console.WriteLine("Digite o NIF do Cliente: ");
                cliente.NIF = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite o NIPC do Cliente: ");
                cliente.NIPC = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite a Data de Nascimento do Cliente: ");
                cliente.DataNascimento = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Número de Telefone do Cliente: ");
                cliente.Telefone = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite a Nacionalidade do Cliente: ");
                cliente.Nacionalidade = Console.ReadLine();
                Console.WriteLine("Digite o Saldo Total do Cliente: ");
                cliente.SaldoTotal = Decimal.Parse(Console.ReadLine());

                return cliente;
            }

            struct conta
            {
                public int N_Conta;
                public int IBAN;
                public DateTime DataAbertura;
                public string TipoConta;
                public int SaldoConta;
            }
        }

        class Cartao
        {
            struct cartao
            {
                public int N_Cartao;
                public DateTime DataValidade;
                public int SaldoCartao;
                public int Codigo;
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}