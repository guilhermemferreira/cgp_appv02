using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace cgp_appv02
{
    internal class Program
    {
        #region Estrutura Clientes
        struct cliente
        {
            public int ID;
            public string Nome;
            //public string Morada;
            public int NIF;
            public int NIPC;
            //public DateTime DataNascimento;
            public int Telefone;
            public string Nacionalidade;
        }

        static int utlimoClienteID = 0;

        static cliente CriarCliente()
        {
            cliente cliente;

            cliente.ID = ++utlimoClienteID;
            
            string nome = Nome();
            if (nome == null)
            {
                Console.WriteLine("Nome inválido.");
            }

            cliente.Nome = nome;


            //string morada = Morada();
            //if (morada == null)
            //{
            //    Console.WriteLine("Morada inválida.");
            //}
            //else
            //{
            //    Console.WriteLine("Morada: " + morada);
            //}
            //cliente.Morada = morada;

            int nif = NIF();

            if (nif == null)
            {
                Console.WriteLine("NIF inválido.");

            }

            cliente.NIF = nif;
            int nipc = NIPC();

            if (nipc == null)
            {
                Console.WriteLine("NIPC inválido.");

            }

            cliente.NIPC = nipc;

            //DateTime dataNascimento = DataNascimento();
            //if (dataNascimento == null)
            //{
            //    Console.WriteLine("Data de nascimento inválida.");
            //}
            //else
            //{
            //    Console.WriteLine("Data de nascimento: " + dataNascimento);
            //}
            //cliente.DataNascimento = dataNascimento;

            int telefone = Telefone();

            if (telefone == null)
            {
                Console.WriteLine("Número de telefone inválido.");

            }
            cliente.Telefone = telefone;

            string nacionalidade = Nacionalidade();

            if (nacionalidade == null)
            {
                Console.WriteLine("Nacionalidade inválida.");

            }
            cliente.Nacionalidade = nacionalidade;


            return cliente;
        }

        static void EscreverClienteEcra(cliente cliente)
        {
            Console.WriteLine("Nome: {0}; NIF: {1}; Nacionalidade {2}; ID: {3}",
                cliente.Nome, cliente.NIF, cliente.Nacionalidade, cliente.ID);
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

        #region Validacao do nome

        static Regex regexNome = new Regex(@"^([A-Z][a-zÀ-ú '´]{2,50}) \b([A-Z][a-zÀ-ú '´]{2,50}) \b([A-Z][a-zÀ-ú '´]{2,50})$");

        static string Nome()
        {
            bool erro;
            string nome = "";
            do
            {
                Console.Write("Insira o seu nome: ");
                erro = false;
                try
                {
                    nome = Console.ReadLine();

                    if (!regexNome.IsMatch(nome))
                    {
                        erro = true;
                        Console.WriteLine(
                            "O nome introduzido é inválido. \n." +
                            "O nome deve conter maiúsculas. \n" +
                            "O nome deve ter pelo menos 2 caracteres e não mais de 50 caracteres.\n" +
                            "O nome deve conter apenas letras, espaço e acentos.\n" +
                            "O nome pode conter o símbolo ' (apóstrofo) ou o símbolo ´ (til).");
                    }
                }
                catch (Exception e)
                {
                    erro = true;
                    Console.WriteLine(
                        "Por favor introduza um nome válido...");
                }
            } while (erro);

            return regexNome.IsMatch(nome) ? nome : null;
        }
        #endregion

        #region Validação da morada
        //static Regex regexMorada = new Regex(@"^(\d{4}-\d{3}) ([\p{L}\s]+), ([\p{L}\s]+)$");

        //static string Morada()
        //{
        //    bool erro;
        //    string morada = "";
        //    do
        //    {
        //        Console.Write("Insira a sua morada: ");
        //        erro = false;
        //        try
        //        {
        //            morada = Console.ReadLine();

        //            if (!regexMorada.IsMatch(morada))
        //            {
        //                erro = true;
        //                Console.WriteLine(
        //                    "A morada deve ter o seguinte formato:\n" +
        //                    "Código Postal[- ]Número[- ]Rua[- ]Localidade");
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            erro = true;
        //            Console.WriteLine(
        //                "Por favor introduza uma morada válida...");
        //        }
        //    } while (erro);

        //    return regexMorada.IsMatch(morada) ? morada : null;
        //}


        #endregion

        #region Validação do NIF
        static Regex regexNIF = new Regex(@"^([1-9]{9})$");

        static int NIF()
        {
            bool erro;
            string nif = "";
            do
            {
                Console.Write("Insira o seu NIF: ");
                erro = false;
                try
                {
                    nif = Console.ReadLine();

                    if (!regexNIF.IsMatch(nif))
                    {
                        erro = true;
                        Console.WriteLine(
                            "O NIF deve ter o seguinte formato:\n" +
                            "123456789 \n" +
                            "O NIF não pode conter menos de 9 dígitos!");
                    }
                }
                catch (Exception e)
                {
                    erro = true;
                    Console.WriteLine(
                        "Por favor introduza um NIF válido...");
                }
            } while (erro);

            return int.Parse(nif);
        }

        #endregion

        #region Validação do NIPC
        static Regex regexNIPC = new Regex(@"^([1-9]{9})$");

        static int NIPC()
        {
            bool erro;
            string nipc = "";
            do
            {
                Console.Write("Insira o seu NIPC: ");
                erro = false;
                try
                {
                    nipc = Console.ReadLine();

                    if (!regexNIF.IsMatch(nipc))
                    {
                        erro = true;
                        Console.WriteLine(
                            "O NIPC deve ter o seguinte formato:\n" +
                            "123456789 \n" +
                            "O NIPC só pode conter 9 caracteres.\n" +
                            "O NIPC não pode conter menos de 9 dígitos!");
                    }
                }
                catch (Exception e)
                {
                    erro = true;
                    Console.WriteLine(
                        "Por favor introduza um NIF válido...");
                }
            } while (erro);

            return int.Parse(nipc);
        }

        #endregion

        //#region Validação da data de nascimento
        //static DateTime DataNascimento()
        //{
        //    bool erro;
        //    DateTime dataNascimento;
        //    string dataNascimentoString;

        //    do
        //    {
        //        Console.Write("Insira a sua data de nascimento (DD/MM/AAAA): ");
        //        erro = false;
        //        try
        //        {
        //            // Declarar a variável dataNascimentoString
        //            dataNascimentoString = Console.ReadLine();

        //            if (!DateTime.TryParse(dataNascimentoString, out dataNascimento))
        //            {
        //                erro = true;
        //                Console.WriteLine(
        //                    "A data de nascimento introduzida é inválida. \n." +
        //                    "A data de nascimento deve estar no formato DD/MM/AAAA.");
        //            }
        //            else if (dataNascimento > DateTime.Today)
        //            {
        //                erro = true;
        //                Console.WriteLine(
        //                    "A data de nascimento não pode ser futura.");
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            erro = true;
        //            Console.WriteLine(
        //                "Por favor introduza uma data de nascimento válida...");
        //        }
        //    } while (erro);

        //    // Atribuir um valor à variável dataNascimento
        //    dataNascimento = DateTime.Parse(dataNascimentoString);

        //    return dataNascimento;
        //}
        //#endregion

        #region Validacao do Contacto telefónico

        static Regex regexTelefone = new Regex(@"^[91|92|93|94|96]{2}\d{7}$");

        static bool TelefoneValido(string telefone)
        {
            return regexTelefone.IsMatch(telefone) && telefone.Length <= 10;
        }
        static int Telefone()
        {
            bool erro;
            int telefone = 0;
            do
            {
                Console.Write("Insira o seu número de telefone (9 dígitos): ");
                erro = false;
                try
                {
                    telefone = Convert.ToInt32(Console.ReadLine());

                    if (!TelefoneValido(telefone.ToString()))
                    {
                        erro = true;
                        Console.WriteLine(
                            "O número de telefone introduzido é inválido. \n." +
                            "O número de telefone deve ser um número de 9 dígitos. \n" +
                            "O número de telefone deve começar por 91, 92, 93, 95 ou 96.");
                    }
                }
                catch (Exception e)
                {
                    erro = true;
                    Console.WriteLine(
                        "Por favor introduza um número de telefone válido...");
                }
            } while (erro);

            return telefone;

        }


        #endregion

        #region Validar nacionalidade
        static Regex regexNacionalidade = new Regex(@"^([a-zA-Z]{2,50})$");

        static string Nacionalidade()
        {
            bool erro;
            string nacionalidade = "";
            do
            {
                Console.Write("Insira a sua nacionalidade: ");
                erro = false;
                try
                {
                    nacionalidade = Console.ReadLine();

                    if (!regexNacionalidade.IsMatch(nacionalidade))
                    {
                        erro = true;
                        Console.WriteLine(
                            "A nacionalidade introduzida é inválida. \n." +
                            "A nacionalidade deve conter apenas letras, espaço e acentos.\n" +
                            "A nacionalidade deve ter pelo menos 2 caracteres e não mais de 50 caracteres.");
                    }
                }
                catch (Exception e)
                {
                    erro = true;
                    Console.WriteLine(
                        "Por favor introduza uma nacionalidade válida...");
                }
            } while (erro);

            return regexNacionalidade.IsMatch(nacionalidade) ? nacionalidade : null;
        }
        #endregion

        #region Conta
        struct conta
        {
            public int IDConta;
            public int IDCliente;
            public int NConta;
            public int IBAN;
            public DateTime DataAbertura;
            public string TipoConta;
            public decimal SaldoTotal;
        }

        static conta CriarConta(int IDConta, int NConta, int IBAN, DateTime DataAbertura, string TipoConta, decimal SaldoTotal)
        {
            conta conta;
            conta.IDConta = IDConta;
            conta.NConta = NConta;
            conta.IBAN = IBAN;
            conta.DataAbertura = DataAbertura;
            conta.TipoConta = TipoConta;
            conta.SaldoTotal = SaldoTotal;
            conta.IDCliente = 0;

            return conta;
        }

        static void ListagemClientes(List<cliente> clientes)
        {
            Console.WriteLine("Clientes existentes:");
            foreach (var cliente in clientes)
            {
                EscreverClienteEcra(cliente);
            }
        }

        static int QualID(List<cliente> clientes)
        {
            Console.WriteLine("Digite o ID do cliente: ");
            int qualid = Convert.ToInt32(Console.ReadLine());

            var cliente = clientes.FirstOrDefault(c => c.ID == qualid);

            if (cliente.ID != 0)
            {
                Console.WriteLine($"Cliente encontrado: {cliente.Nome} (ID: {cliente.ID})");
            }
            else
            {
                Console.WriteLine($"O Cliente com o ID {qualid} não existe!");
            }
            return qualid;
        }

        #region Qual ID Conta
        static int QualIDConta(List<conta> contas, List<cliente> clientes)
        {
            Console.WriteLine("Digite o ID do cliente: ");
            int clienteID = Convert.ToInt32(Console.ReadLine());

            // Verifica se o cliente com o ID fornecido existe
            var cliente = clientes.FirstOrDefault(c => c.ID == clienteID);

            if (clientes != null)
            {
                // Encontra a primeira conta associada ao cliente
                var conta = contas.FirstOrDefault(c => c.IDCliente == clienteID);

                if (contas != null)
                {
                    Console.WriteLine($"Conta encontrada para o cliente {cliente.Nome} (ID do Cliente: {clienteID})");
                    Console.WriteLine($"ID da Conta: {conta.IDConta}");
                    return conta.IDConta;
                }
                else
                {
                    Console.WriteLine($"O cliente {cliente.Nome} (ID: {clienteID}) não possui uma conta.");
                    return -1; // Retorna um valor indicando que a conta não foi encontrada
                }
            }
            else
            {
                Console.WriteLine($"O Cliente com o ID {clienteID} não existe!");
                return -1; // Retorna um valor indicando que o cliente não foi encontrado
            }
        }
        #endregion

        static int QualIDMostrar(List<cliente> clientes, conta conta)
        {
            Console.WriteLine("Qual é o ID do Cliente: ");
            int idcliente = Convert.ToInt32(Console.ReadLine());

            var cliente = clientes.FirstOrDefault(c => c.ID == idcliente);

            if (cliente.ID != null)
            {
                Console.WriteLine($"Cliente encontrado: {cliente.Nome} (ID: {cliente.ID})");
                conta.IDCliente = idcliente;
            }
            else
            {
                Console.WriteLine($"O Cliente com o ID {idcliente} não existe!");
            }

            return idcliente;
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

        static int utlimaContaID = 0;
        static conta LerConta()
        {
            conta conta;
            conta.NConta = 0;
            conta.IBAN = 0;
            conta.IDCliente = 0;
            conta.IDConta = ++utlimaContaID;
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
            for (int i = 0; i < quantascontas; i++)
            {
                Console.WriteLine("Conta {0}", i + 1);
                atemp = LerConta();
                arrayconta[i] = atemp;
            }
            return arrayconta;
        }

        static void EscreverConta(conta conta)
        {
            Console.WriteLine("Conta: {0}, Tipo: {1}, Saldo: {2}, ID: {3}",
                conta.NConta, conta.TipoConta, conta.SaldoTotal, conta.IDConta);
        }


        static void EscreverContas(conta[] arrayconta, int quantascontas)
        {
            conta atemp;
            for (int i = 0; i < quantascontas; i++)
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

        static cartao[] LerCartoes(cartao[] arraycartao, int quantoscartoes)
        {
            cartao atemp;
            for (int i = 0; i < quantoscartoes; i++)
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
            for (int i = 0; i < quantoscartoes; i++)
            {
                atemp = arraycartao[i];
                EscreverCartao(atemp);
            }
        }
        #endregion

        static int Menu()
        {
            Console.WriteLine("\nMenu | Programa Alunos (List)");
            Console.WriteLine("------+-----------------------------------");
            Console.WriteLine(" 1 | Adicionar Clientes / Contas / Cartões");
            Console.WriteLine(" 2 | Mostrar Clientes / Contas / Cartões");
            Console.WriteLine(" 3 | Mostrar Movimentos da Conta");
            Console.WriteLine(" 0 | Sair / Terminar o programa");
            Console.Write("Escolha uma opção: ");
            int opcaopr = Convert.ToInt32(Console.ReadLine());
            return opcaopr;
        }

        static void Main(string[] args)
        {
            List<cliente> clientes = new List<cliente>();
            List<conta> contas = new List<conta>();
            List<cartao> cartoes = new List<cartao>();

            conta[] conta = null;
            cartao[] cartao = null;

            int quantascontas = 0;

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

                    case 3:
                        ListagemClientes(clientes);
                        int idSelecionado = QualID(clientes);
                        quantascontas = QuantasContas();
                        conta = CriarArrayConta(quantascontas);
                        LerContas(conta, quantascontas);
                        EscreverContas(conta, quantascontas);
                        break;


                    case 4:
                        EscreverContas(conta, quantascontas);
                        break;

                    case 5:
                        ListagemClientes(clientes);
                        int qualidconta = QualIDConta(contas, clientes);
                        break;
                }

            } while (opcao != 0);
        }
    }
}
