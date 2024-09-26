using Domain.Models;
using System.Collections.Generic;

namespace GeladeiraTeste
{
    public class TesteItem
    {
        private Item _item = new Item();

        public TesteItem()
        {
            _item.Items = new List<Item>();

            for (int i = 0; i < 4; i++)
                _item.Items.Add(new Item());
        }

        [Theory]
        [InlineData(0, 1, 1)]
        public void RemoverItem_Success(int numAndar, int numContainer, int posicao)
        {
            _item.RemoverItem(numAndar, numContainer, posicao);
            Assert.True(true);
        }

        [Fact]
        public void AdicionarTodosItens_Success()
        {
            var andar = new Andar(1, "Laticínios");

            _item.Items = andar.Containers[0].Items;


            Item itemMaca = new Item() { DescricaoItem = "Maçã", Quantidade = 1, UnidadeQtd = "Unidade", Classificacao = "Fruta", IdItem = 1 };
            Item itemBanana = new Item() { DescricaoItem = "Banana", Quantidade = 1, UnidadeQtd = "Cacho", Classificacao = "Fruta", IdItem = 2 };
            Item itemLaranja = new Item() { DescricaoItem = "Laranja", Quantidade = 1, UnidadeQtd = "Duzia", Classificacao = "Fruta", IdItem = 3 };

            List<Item> novosItens = new List<Item>() {itemMaca, itemBanana, itemLaranja};

            _item.AdicionarTodosItens(novosItens);

            Assert.NotNull(_item.Items.Where(i => i.IdItem > 0).First()); 
        }

        [Fact]
        public void AdicionarItens_QtdItens_Ultrapasssado_Test()
        {
            var andar = new Andar(1, "Laticínios");

            _item.Items = andar.Containers[0].Items;

            Item item = new Item() { DescricaoItem = "leite", IdItem = 1 };
            Item item1 = new Item() { DescricaoItem = "iogurte", IdItem = 2 };
            Item item2 = new Item() { DescricaoItem = "queijo", IdItem = 3 };
            Item item3 = new Item() { DescricaoItem = "doce de leite", IdItem = 4 };
            Item item4 = new Item() { DescricaoItem = "muçarela", IdItem = 5 };

            List<Item> novosItens = new List<Item>() { item, item1, item2, item3, item4 };

            Assert.Throws<Exception>(() => _item.AdicionarTodosItens(novosItens));
        }

        [Fact]
        public void AdicionarItens_QtdItens_ContainerCheio_Test()
        {
            var andar = new Andar(1, "Laticínios");

            Item item = new Item() { DescricaoItem = "leite", IdItem = 1 };
            Item item1 = new Item() { DescricaoItem = "iogurte", IdItem = 2 };
            Item item2 = new Item() { DescricaoItem = "queijo", IdItem = 3 };
            Item item3 = new Item() { DescricaoItem = "requeijao", IdItem = 4 };

            _item.Items = new List<Item>() { item, item1, item2, item3 };

            Item item4 = new Item() { DescricaoItem = "mussarela", IdItem = 5 };
            Item item5 = new Item() { DescricaoItem = "queijo prato", IdItem = 6 };
            Item item6 = new Item() { DescricaoItem = "sorvete", IdItem = 7 };

            List<Item> novosItens = new List<Item>() { item4, item5, item6 };

            Assert.Throws<Exception>(() => _item.AdicionarTodosItens(novosItens));
        }

        [Fact]
        public void AdicionarItem_Test()
        {
            Item item = new Item() { DescricaoItem = "leite", IdItem = 1 };

            _item.AdicionarItem(1, 0, 0, item);

            Assert.True(true);
        }

        [Fact]
        public void AdicionarItem_Exception_Test()
        {
            Item item = new Item() { DescricaoItem = "leite", IdItem = 1 };

            Assert.Throws<Exception>(() => _item.AdicionarItem(1, 5, 0, item));
        }

        [Fact]
        public void AdicionarItens_Parametros_Test()
        {
            Item item = new Item() { DescricaoItem = "leite", IdItem = 1 };
            Item item1 = new Item() { DescricaoItem = "iogurte", IdItem = 2 };
            Item item2 = new Item() { DescricaoItem = "queijo", IdItem = 3 };
            Item item3 = new Item() { DescricaoItem = "doce de leite", IdItem = 4 };

            List<Item> novosItens = new List<Item>() { item, item1, item2, item3 };

            _item.AddItens(1, 0, novosItens);

            Assert.True(true);
        }
    }
}