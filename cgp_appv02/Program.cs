using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace cgp_appv02
{
    internal class Program
    {
        #region Estrutura Clientes
        struct cliente
        {
            public string Nome;
            public string Morada;
            public int NIF;
            public int NIPC;
            public DateTime DataNascimento;
            public int Telefone;
            public string Nacionalidade;
        }
        static cliente CriarCliente()
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
            Console.WriteLine("Digite o Telefone do Cliente: ");
            cliente.Telefone = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a Nacionalidade do Cliente: ");
            cliente.Nacionalidade = Console.ReadLine();

            return cliente;
        }

        static void EscreverClienteEcra(cliente cliente)
        {
            Console.WriteLine("Nome: {0}; NIF: {1}; Nacionalidade {2}",
                cliente.Nome, cliente.NIF, cliente.Nacionalidade);
        }

        static void EscreverClientesEcra(List<cliente> clientes)
        {
            Console.WriteLine("Clientes existentes:");
            foreach (var cliente in clientes)
            {
                EscreverClienteEcra(cliente);
            }
        }
        #endregion

        #region Conta
        struct conta
        {
            public int NConta;
            public int IBAN;
            public DateTime DataAbertura;
            public string TipoConta;
            public decimal SaldoTotal;
        }

        static conta CriarConta(int NConta, int IBAN, DateTime DataAbertura, string TipoConta, decimal SaldoTotal)
        {
            conta conta;
            conta.NConta = NConta; 
            conta.IBAN = IBAN;
            conta.DataAbertura = DataAbertura;
            conta.TipoConta = TipoConta;
            conta.SaldoTotal = SaldoTotal;

            return conta;
        }

        static int QuantasContas()
        {
            Console.WriteLine("Digite quantas contas pretende criar: ");
            int quantascontas = Convert.ToInt32(Console.ReadLine());

            return quantascontas;
        }

        static conta[] CriarArrayConta(int quantascontas) 
        {
            conta[] arrayconta = new conta[quantascontas];
            return arrayconta;
        }

        static conta LerConta()
        {
            conta conta;
            conta.NConta = 0;
            conta.IBAN = 0;
            Console.WriteLine("Digite a data de abertura da Conta: ");
            conta.DataAbertura = DateTime.Parse(Console.ReadLine());    
            Console.WriteLine("Digite o Tipo de Conta: ");
            conta.TipoConta = Console.ReadLine();
            Console.WriteLine("Digite o Saldo da Conta: ");
            conta.SaldoTotal = Decimal.Parse(Console.ReadLine());   

            return conta;
        }

        static conta[] LerContas(conta[] arrayconta, int quantascontas)
        {
            conta atemp;
            for(int i = 0; i < quantascontas; i++)
            {
                Console.WriteLine("Conta {0}", i + 1);
                atemp = LerConta();
                arrayconta[i] = atemp;
            }
            return arrayconta;
        }

        static void EscreverConta(conta conta)
        {
            Console.WriteLine("Conta: {0}, Tipo: {1}, Saldo: {2}",
                conta.NConta, conta.TipoConta, conta.SaldoTotal);
        }

        static void EscreverContas(conta[] arrayconta, int quantascontas)
        {
            conta atemp;
            for(int i = 0; i < quantascontas;i++)
            {
                atemp = arrayconta[i];
                EscreverConta(atemp);
            }
        }
        #endregion

        #region Estrutura Cartao
        struct cartao
        {
            public int NCartao;
            public DateTime DataValidade;
            public decimal SaldoCartao;
            public int Codigo;
        }

        static cartao CriarCartao(int NCartao, DateTime DataValidade, decimal SaldoCartao, int Codigo)
        {
            cartao cartao;
            cartao.NCartao = NCartao;
            cartao.DataValidade = DataValidade;
            cartao.SaldoCartao = SaldoCartao;
            cartao.Codigo = Codigo;

            return cartao;
        }

        static int QuantosCartoes()
        {
            Console.WriteLine("Quantos Cartões é que quer associar à Conta: ");
            int quantoscartoes = Convert.ToInt32(Console.ReadLine());

            return quantoscartoes;
        }

        static cartao[] CriarArrayCartao(int quantoscartoes)
        {
            cartao[] arraycartao = new cartao[quantoscartoes];
            return arraycartao;
        }

        static cartao CriarCartao()
        {
            cartao cartao;
            cartao.NCartao = 0;
            Console.WriteLine("Data de Validade: ");
            cartao.DataValidade = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Saldo do Cartão: ");
            cartao.SaldoCartao = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Codigo do Cartão: ");
            cartao.Codigo = Convert.ToInt32(Console.ReadLine());

            return cartao;
        }

        static cartao[] LerCartoes(cartao[] arraycartao,int quantoscartoes)
        {
            cartao atemp;
            for(int i = 0; i < quantoscartoes; i++)
            {
                Console.WriteLine("Cartão: {0}", i + 1);
                atemp = CriarCartao();
                arraycartao[i] = atemp;
            }
            return arraycartao;
        }

        static void EscreverCartao(cartao cartao) 
        {
            Console.WriteLine("Nº Conta: {0}, Saldo: {1}, Codigo: {2}",
                cartao.NCartao, cartao.SaldoCartao, cartao.Codigo);
        }

        static void EscreverCartoes(cartao[] arraycartao, int quantoscartoes)
        {
            cartao atemp;
            for(int i = 0; i < quantoscartoes;i++)
            {
                atemp = arraycartao[i];
                EscreverCartao(atemp);
            }
        }
        #endregion

        static int Menu()
        {
            Console.WriteLine("\nMenu | Programa Alunos (List)");
            Console.WriteLine("------+--------------");
            Console.WriteLine(" 1 | Adicionar Cliente");
            Console.WriteLine(" 2 | Mostrar Clientes");
            Console.WriteLine(" 0 | Sair / Terminar o programa");
            Console.Write("Escolha uma opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());
            return opcao;
        }

        static void Main(string[] args)
        {
            List<cliente> clientes = new List<cliente>();

            int opcao;
            do
            {
                opcao = Menu();
                switch (opcao)
                {
                    case 1:
                        cliente novoCliente = CriarCliente();
                        clientes.Add(novoCliente);
                        break;

                    case 2:
                        EscreverClientesEcra(clientes);
                        break;
                }

            } while (opcao != 0);
        }
    }
}
