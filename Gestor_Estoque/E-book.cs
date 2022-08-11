using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Estoque
{
    [System.Serializable]
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;
        
        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada no estoque E-book pois é um produto digital\nPressione ENTER para Sair !");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicione vendas no E-book {nome}\n");
            Console.WriteLine("Digite a quantidade de vendas obtidas: ");
            int entrada = int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("Venda registrada com sucesso !");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome do E-Book: {nome}");
            Console.WriteLine($"Preço: {preco}$");
            Console.WriteLine($"Autor do E-Book: {autor}");
            Console.WriteLine($"Vendas atuais: {vendas}");
            Console.WriteLine("=========================");
        }
    }
}
