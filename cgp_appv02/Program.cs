using System;
using System.Collections.Generic;

namespace cgp_appv02
{
    internal class Program
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
