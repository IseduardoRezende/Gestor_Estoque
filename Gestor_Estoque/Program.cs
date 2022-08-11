using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gestor_Estoque //Cadastra Prod, Registra Prod, Entrada e Saída haverá ocorrência, 3 tipos de Produtos;
{
    class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saída, Sair  }
        static void Main(string[] args)
        {
            Carregar();

            bool escolheuSair = false;
            while(escolheuSair == false)
            {
                Console.WriteLine("Sistema de Estoque !");
                Console.WriteLine("1-Lista de Produtos\n2-Adicionar Produto\n3-Remover Produto\n4-Registrar Entrada\n5-Registrar Saída\n6-Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                Menu escolha = (Menu)opInt;

                if (opInt > 0 && opInt < 7)
                {
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saída:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Erro ! Tente novamente");
                    Console.ReadLine();
                    escolheuSair = true;
                }

                Console.Clear();
            }
        }
        static void Listagem()
        {
            if (produtos.Count > 0)
            {
                Console.WriteLine("Lista de Produtos:");
                int i = 0;
                foreach (IEstoque produto in produtos)
                {
                    Console.WriteLine("ID: " + i);
                    produto.Exibir();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto encontrado !");
            }
    
            Console.ReadLine();
        }
        static void Remover()
        {
            if (produtos.Count < 0)
            {
                Console.WriteLine("Erro, tente cadastrar algum Produto");
            }
            else
            {
                Listagem();
                Console.WriteLine("Escolha o ID do Produto que deseja remover:\n ");
                int id = int.Parse(Console.ReadLine());
                if (id < produtos.Count)
                {
                   produtos.RemoveAt(id);
                   Salvar();
                }
            }
        }
        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do produto que deseja dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
            else
            {
                Console.WriteLine("Nenhum produto encontrado para dar entrada !");
            }
        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do produto que deseja dar saída: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
            else
            {
                Console.WriteLine("Nenhum produto encontrado para dar Saída !");
            }
        }
        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produtos:");
            Console.WriteLine("1-Produto Físico\n2-E-Book\n3-Curso");
            string opStr = Console.ReadLine();  //desenvolver com Enum é uma possibilidade:
            int escolhaInt = int.Parse(opStr);
            switch (escolhaInt)
            {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
        }

        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando Produto Físico: ");
            Console.WriteLine("Nome do Produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço do Produto: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete do Produto: ");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFísico pf = new ProdutoFísico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastroo de E-Book:");
            Console.WriteLine("Nome do E-book: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço E-Book: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor do E-Book: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Nome do Curso: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço do curso: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor do Curso: ");
            string autor = Console.ReadLine();

            Curso curso = new Curso(nome, preco, autor);
            produtos.Add(curso);
            Salvar();
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if (produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch (Exception)
            {
                produtos = new List<IEstoque>();
            }
           
            stream.Close();
        }
    }
}
