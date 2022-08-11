using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Estoque
{
    [System.Serializable]
    class ProdutoFísico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFísico(string nome, float preco, float frete) 
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicione entrada no estoque do produto {nome}\n");
            Console.WriteLine("Digite a quantidade que deseja dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada Registrada !");
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicione saída no estoque do produto {nome}\n ");
            Console.WriteLine("Digite a quantidade que deseja retirar: ");
            int retirar = int.Parse(Console.ReadLine());
            estoque -= retirar;
            Console.WriteLine("Retirado com sucesso !");
            Console.ReadLine();
           
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome do Produto: {nome}");
            Console.WriteLine($"Preço do Produto: {preco}$");
            Console.WriteLine($"Frete do Produto: {frete}");
            Console.WriteLine($"Estoque atual: {estoque}");
            Console.WriteLine("=========================");
        }
    }
}
