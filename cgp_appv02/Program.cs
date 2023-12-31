﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
            public string Morada;
            public int NIF;
            public int NIPC;
            public DateTime DataNascimento;
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

            DateTime dataNascimento = DataNascimento();
            cliente.DataNascimento = dataNascimento;

            Morada moradaCliente = MoradaCliente();
            cliente.Morada = moradaCliente.ToString();


            return cliente;
        }

        static void EscreverClienteEcra(cliente cliente)
        {
            Console.WriteLine("Nome: {0}; NIF: {1}; NIPC: {2}; Data Nascimento {3}; Telefone: {4}; Nacionalidade: {5}; Morada: {6};ID: {7}",
                cliente.Nome, cliente.NIF, cliente.NIPC,
                cliente.DataNascimento, cliente.Telefone, cliente.Nacionalidade, cliente.Morada,
                cliente.ID);
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

        #region Validações

        #region Validacao do nome

        static Regex regexNome = new Regex(@"^[\p{L}'´]+\s([\p{L}'´]+(\s|.|,|-)?){1,9}[\p{L}'´]+$");
        static string Nome()
        {
            Console.Clear();
            bool erro;
            string nome = "";
            do
            {
                Console.Write("Insira o seu Nome Completo: ");
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

        #region Validação da Data de Nascimento
        static DateTime DataNascimento()
        {
            bool erro;
            DateTime dataNascimento = DateTime.MinValue;

            do
            {
                Console.Write("Insira a sua data de nascimento (dd/mm/yyyy): ");
                erro = false;
                try
                {
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, 
                        DateTimeStyles.None, out dataNascimento))
                    {
                        DateTime dataAtual = DateTime.Now;
                        int idade = dataAtual.Year - dataNascimento.Year;

                        if (dataNascimento > dataAtual.AddYears(-idade))
                        {
                            idade--;
                        }
                        if (idade < 18)
                        {
                            erro = true;
                            Console.WriteLine("A data de nascimento introduzida não é válida. A pessoa deve ter mais de 18 anos!");
                        }
                        if (idade >= 110)
                        {
                            erro = true;
                            Console.WriteLine("A data de nascimento introduzida não é válida. A pessoa deve ter menos de 110 anos.");
                        }
                    }
                    else
                    {
                        erro = true;
                        Console.WriteLine("A data de nascimento introduzida não é válida. Utilize o formato dd/mm/yyyy.");
                    }
                }
                catch (Exception e)
                {
                    erro = true;
                    Console.WriteLine("Por favor, introduza uma data de nascimento válida.");
                }
            } while (erro);

            return dataNascimento;
        }
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

        #region Validar Morada
        public struct Morada
        {
            public string TipoRua;
            public string NomeRua;
            public string Andar;
            public string Porta;
            public string Localidade;
            public override string ToString()
            {
                return $"{TipoRua} {NomeRua}, {Andar} {Porta}, {Localidade}";
            }
        }

        static Morada MoradaCliente()
        {
            Console.Clear();

            Morada morada = new Morada();

            Console.WriteLine("Introduza a morada:");

            Console.Write("Tipo de Rua/Avenida (Primeira letra maiúscula): ");
            morada.TipoRua = Console.ReadLine();
            while (!Regex.IsMatch(morada.TipoRua, @"^[A-Z][a-z]*$"))
            {
                Console.WriteLine("Tipo de Rua inválido. Deve começar com letra maiúscula.");
                Console.Write("Tipo de Rua/Avenida (Primeira letra maiúscula): ");
                morada.TipoRua = Console.ReadLine();
            }

            Console.Write("Nome da Rua (Primeira letra maiúscula): ");
            morada.NomeRua = Console.ReadLine();
            while (!Regex.IsMatch(morada.NomeRua, @"^[A-Z][a-zA-Z\s]*$"))
            {
                Console.WriteLine("Nome da Rua inválido. Deve começar com letra maiúscula e conter apenas letras e espaços.");
                Console.Write("Nome da Rua (Primeira letra maiúscula): ");
                morada.NomeRua = Console.ReadLine();
            }

            Console.Write("Número do Andar / Vivenda: ");
            string na = Console.ReadLine();

            if (int.TryParse(na, out int andar))
            {
                string numeroAndarComSimbolo = andar + "º";
                morada.Andar = numeroAndarComSimbolo;
            }
            else
            {
                morada.Andar = na;
            }

            Console.Write("Porta (pode ser uma direção ou letra): ");
            morada.Porta = Console.ReadLine();

            Console.Write("Localidade (Primeira letra maiúscula): ");
            morada.Localidade = Console.ReadLine();
            while (!Regex.IsMatch(morada.Localidade, @"^[A-Z][a-z]*$"))
            {
                Console.WriteLine("Localidade inválida. Deve começar com letra maiúscula.");
                Console.Write("Localidade (Primeira letra maiúscula): ");
                morada.Localidade = Console.ReadLine();
            }

            return morada;
        }

        #endregion

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
            if (cliente.ID != null)
            {
                Console.WriteLine($"Cliente encontrado: {cliente.Nome} (ID: {cliente.ID})");
            }
            else
            {
                Console.WriteLine($"O Cliente com o ID {qualid} não existe!");
                return qualid;
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

        static int Menu()
        {
            Console.WriteLine("\nMenu | Caixa Geral de Pobres");
            Console.WriteLine("------+--------------");
            Console.WriteLine(" 1 | Adicionar Cliente");
            Console.WriteLine(" 2 | Mostrar Clientes");
            Console.WriteLine(" 3 | Criar Conta");
            Console.WriteLine(" 4 | Mostrar Conta");
            Console.WriteLine(" 0 | Sair / Terminar o programa");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            if (!Char.IsDigit(opcao[0]))
            {
                Console.Clear();
                Console.WriteLine("Opção inválida. Escolha uma opção entre 1 e 4.");
                return Menu();
            }

            int opcaoInt = Convert.ToInt32(opcao);

            if (!ValidarOpcao(opcaoInt))
            {
                Console.WriteLine("Opção inválida. Escolha uma opção entre 1 e 3.");
                return Menu();
            }

            return opcaoInt;
        }

        static bool ValidarOpcao(int opcao)
        {
            return opcao >= 1 && opcao <= 5;
        }


        static void Main(string[] args)
        {
            List<cliente> clientes = new List<cliente>();
            List<conta> contas = new List<conta>();

            conta[] conta = null;

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
