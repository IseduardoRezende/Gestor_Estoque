using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Estoque
{
    [System.Serializable]
    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vaga;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicione vagas do curso {nome}\n");
            Console.WriteLine("Digite a quantidade de vagas que quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vaga += entrada;
            Console.WriteLine("Entrada Registrada !");
            Console.ReadLine();  
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Retire vagas do curso {nome}\n");
            Console.WriteLine("Digite a quantidade de vagas que deseja remover: ");
            int remover = int.Parse(Console.ReadLine());
            vaga -= remover;
            Console.WriteLine("Retirado com sucesso !");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome do curso: {nome}");
            Console.WriteLine($"Preço atual: {preco}$");
            Console.WriteLine($"Vagas disponiveis: {vaga}");
            Console.WriteLine($"Autor do curso: {autor}");
            Console.WriteLine("=========================");
        }
    }
}
