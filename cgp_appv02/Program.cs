namespace cgp_appv02
{
    internal class Program
    {
        class Cliente
        {
            #region Estrutaração Cliente
            public string Nome;
            public string Morada;
            public int NIF;
            public int NIPC;
            public DateTime DataNascimento;
            public int Telefone;
            public string Nacionalidade;
            public decimal SaldoTotal;
            #endregion

            #region Lista de Associação das Contas e dos Cartões ao Cliente
            public List<Conta> Contas { get; set; }
            public List<Cartao> Cartoes { get; set; }
            #endregion

            #region Função no qual define o Cliente (funciona da mesma maneira que a função CriarCliente)
            public Cliente(string Nome, string Morada, int NIF, int NIPC, DateTime DataNascimento, int Telefone, string Nacionalidade, decimal SaldoTotal)
            {
                this.Nome = Nome;
                this.Morada = Morada;
                this.NIF = NIF;
                this.NIPC = NIPC;
                this.DataNascimento = DataNascimento;
                this.Telefone = Telefone;
                this.Nacionalidade = Nacionalidade;
                this.SaldoTotal = SaldoTotal;

                this.Contas = new List<Conta>();
                this.Cartoes = new List<Cartao>();
            }
            #endregion

            #region Definição de Quantos Clientes | Criação de Array
            static int QuantosClientes()
            {
                Console.WriteLine("Introdusa o número de Clientes que Deseja Criar: ");
                int quantosclientes = Convert.ToInt32(Console.ReadLine());

                return quantosclientes;
            }

            static Cliente[] ArrayCliente(int quantosclientes)
            {
                Cliente[] arraycliente = new Cliente[quantosclientes];
                return arraycliente;
            }
            #endregion

            #region Ler Cliente
            public static Cliente LerCliente()
            {
                Console.WriteLine("Insira o nome do cliente:");
                string Nome = Console.ReadLine();
                Console.WriteLine("Insira a morada do cliente:");
                string Morada = Console.ReadLine();
                Console.WriteLine("Insira o NIF do cliente:");
                int NIF = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o NIPC do cliente:");
                int NIPC = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira a data de nascimento do cliente:");
                DateTime DataNascimento = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Insira o telefone do cliente:");
                int Telefone = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira a nacionalidade do cliente:");
                string Nacionalidade = Console.ReadLine();
                Console.WriteLine("Insira o saldo total do cliente:");
                decimal SaldoTotal = decimal.Parse(Console.ReadLine());

                Cliente cliente = new Cliente(Nome, Morada, NIF, NIPC, DataNascimento, Telefone, Nacionalidade, SaldoTotal);

                return cliente;
            }
            #endregion

            #region Ler Clientes Array
            static Cliente[] LerClientesArray(Cliente[] arraycliente, int quantosclientes)
            {
                Cliente cliente;
                for(int i = 0; i < quantosclientes; i++)
                {
                    Console.WriteLine("Aluno {0}", i + 1);
                    cliente = LerCliente();
                    arraycliente[i] = cliente;
                }

                return arraycliente;
            }
            #endregion

            static void ClienteEcra(Cliente cliente)
            {
                Console.WriteLine("Cliente: {0}, {1}: {2}.",
                    cliente.Nome, cliente.NIF, cliente.Telefone);
            }

            static void ClientesEcra(Cliente[] arraycliente, int quantosclientes)
            {
                Cliente cliente;
                for(int i = 0; i < quantosclientes; i++)
                {
                    cliente = arraycliente[i];
                    ClienteEcra(cliente);
                }
            }
        }

        class Conta
        {
            #region Estruturação de Conta
            public int N_Conta;
            public int IBAN;
            public DateTime DataAbertura;
            public decimal SaldoConta;

            struct TipoConta
            {
                public string NomeConta;
                public decimal TaxaJuros;
            }
            #endregion

            #region Listagem dos Movimentos
            public List<Movimento> Movimentos { get; set; }
            #endregion

            #region Função no qual define o Conta (funciona da mesma maneira que a função CriarConta)
            public Conta(int N_Conta, int IBAN, DateTime DataAbertura, string TipoConta, decimal SaldoConta)
            {
                this.N_Conta = N_Conta;
                this.IBAN = IBAN;
                this.DataAbertura = DataAbertura;
                this.TipoConta = TipoConta;
                this.SaldoConta = SaldoConta;
            }
            #endregion

            #region Função Ler Conta
            public static Conta LerConta()
            {
                int N_Conta = 0;
                int IBAN = 0;
                DateTime DataAbertura = DateTime.Now;
                Console.WriteLine($"Data de Abertura: {DataAbertura}");
                Console.WriteLine("Digite o Tipo de Conta: ");
                string TipoConta = Console.ReadLine();
                Console.WriteLine("Digite o Saldo da Conta: ");
                decimal SaldoConta = Decimal.Parse(Console.ReadLine());

                Conta conta = new Conta(N_Conta, IBAN, DataAbertura, TipoConta, SaldoConta);

                return conta;
            }
            #endregion

        }

        class Cartao
        {
            #region Estrutura do Cartão
            public int N_Cartao;
            public DateTime DataValidade;
            public decimal SaldoCartao;
            public int Codigo;
            #endregion

            #region Função no qual define o Cartão (funciona da mesma maneira que a função CriarCartão)
            public Cartao(int N_Cartao, DateTime DataValidade, decimal SaldoCartao, int Codigo)
            {
                this.N_Cartao = N_Cartao;
                this.DataValidade = DataValidade;
                this.SaldoCartao = SaldoCartao;
                this.Codigo = Codigo;
            }
            #endregion

            #region Função Ler Cartão
            public static Cartao LerCartao()
            {
                int N_Cartao = 0;
                DateTime DataValidade = DateTime.Now.AddYears(4);
                Console.WriteLine("Digite o Saldo do Cartão: ");
                decimal SaldoCartao = Decimal.Parse(Console.ReadLine());
                Console.WriteLine("Digite um código PIN do Cartão: ");
                int Codigo = Convert.ToInt32(Console.ReadLine());

                Cartao cartao = new Cartao(N_Cartao, DataValidade, SaldoCartao, Codigo);

                return cartao;
            }
            #endregion
        }

        static void Main(string[] args)
        {
            //Cliente cliente = Cliente.LerCliente();
            List<Cliente> clientes = new List<Cliente>();

        }
    }
}