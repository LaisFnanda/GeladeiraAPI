using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Item
    {
        public int IdItem { get; set; }

        public string DescricaoItem { get; set; } = string.Empty;

        public int Quantidade { get; set; }

        public string UnidadeQtd { get; set; } = string.Empty;

        public string Classificacao { get; set; } = string.Empty;

        public int Andar { get; set; }

        public int? Container { get; set; }

        public int? Posicao { get; set; }

        public List<Item> Items;

        public Item()
        {

        }

        public void AdicionarItens(List<Item> itens)
        {
            if (itens.Count > Items.Count)
                throw new Exception("Quantidade de itens ultrapassa o limite permitido!");

            int posicao = 0;

            foreach (var item in itens)
            {
                while (posicao < Items.Count && !string.IsNullOrEmpty(Items[posicao]?.DescricaoItem))
                    posicao++;

                if (posicao < Items.Count)
                    Items[posicao] = item;

                else
                    throw new Exception("Container está cheio! Não é permitido incluir itens no momento!");
            }
        }

        public void AdicionarItem(int numAndar, int numContainer, int posicao, Item item)
        {
            var arrAndares = new Andar().RetornarAndares(numAndar);

            Container? container = new Container().RetornarContainer(numAndar, numContainer, arrAndares);

            if (container is null)
                container = arrAndares?.Find(a => a.NumeroAndar == numAndar)?
                               .Containers.Find(c => c.NumeroContainer == numContainer);

            if (container == null)
                throw new Exception("Numero do container inválido!");

            container.AdicionarItem(posicao, item);
        }

        public void AddItens(int numAndar, int numContainer, List<Item> itens)
        {
            var arrAndares = new Andar().RetornarAndares(numAndar);

            Container? container = new Container().RetornarContainer(numAndar, numContainer, arrAndares);

            if (!Convert.ToBoolean(container?.EstaCheio()))
                AdicionarItens(itens);
            else
                throw new Exception("Container já está cheio!");
        }

        public void RemoverItem(int numAndar, int numContainer, int posicao)
        {
            var arrAndares = new Andar().RetornarAndares(numAndar);

            Container? container = new Container().RetornarContainer(numAndar, numContainer, arrAndares);

            container?.RemoverItem(posicao);
        }
    }
}
