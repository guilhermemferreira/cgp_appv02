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

            #region Funções de Adicionar e Obter Contas e Cartões do Cliente
            public void AdicionarConta(Conta conta)
            {
                this.Contas.Add(conta);
            }

            public void AdicionarCartao(Cartao cartao)
            {
                this.Cartoes.Add(cartao);
            }

            public List<Conta> ObterContas()
            {
                return this.Contas;
            }

            public List<Cartao> ObterCartoes()
            {
                return this.Cartoes;
            }
            #endregion
        }

        class Conta
        {
            #region Estruturação de Conta
            public int N_Conta;
            public int IBAN;
            public DateTime DataAbertura;
            public string TipoConta;
            public int SaldoConta;
            #endregion

            #region Função no qual define o Conta (funciona da mesma maneira que a função CriarConta)
            public Conta(int N_Conta, int IBAN, DateTime DataAbertura, string TipoConta, int SaldoConta)
            {
                this.N_Conta = N_Conta;
                this.IBAN = IBAN;
                this.DataAbertura = DataAbertura;
                this.TipoConta = TipoConta;
                this.SaldoConta = SaldoConta;
            }
            #endregion
        }

        class Cartao
        {
            #region Estrutura do Cartão
            public int N_Cartao;
            public DateTime DataValidade;
            public int SaldoCartao;
            public int Codigo;
            #endregion

            #region Função no qual define o Cartão (funciona da mesma maneira que a função CriarCartão)
            public Cartao(int N_Cartao, DateTime DataValidade, int SaldoCartao, int Codigo)
            {
                this.N_Cartao = N_Cartao;
                this.DataValidade = DataValidade;
                this.SaldoCartao = SaldoCartao;
                this.Codigo = Codigo;
            }
        }
        #endregion

        static void Main(string[] args)
        {
            //Cliente cliente = Cliente.LerCliente();


        }
    }
}