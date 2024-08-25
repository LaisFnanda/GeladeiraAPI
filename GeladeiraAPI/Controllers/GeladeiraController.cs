using Domain;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GeladeiraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeladeiraController : ControllerBase
    {
         int id;
         private List<Item> lstgeladeira;

        public GeladeiraController()
        {
            // andar 2 - Hortifrutis
            var objItemMaca = new Item() { Descricao = "Maçã", Quantidade = 1, UnidadeQtd = "Unidade", Classificacao = "Fruta", ID = 1 };
            var objItemBanana = new Item() { Descricao = "Banana", Quantidade = 1, UnidadeQtd = "Cacho", Classificacao = "Fruta", ID = 2 };
            var objItemLaranja = new Item() { Descricao = "Laranja", Quantidade = 1, UnidadeQtd = "Duzia", Classificacao = "Fruta", ID = 3 };

            // andar 1 - Laticínios e Enlatados
            var objItemLeite = new Item() { Descricao = "Leite", Quantidade = 1, UnidadeQtd = "Litro", Classificacao = "Laticínio", ID = 4 };
            var objItemQueijo = new Item() { Descricao = "Queijo", Quantidade = 1, UnidadeQtd = "Unidade", Classificacao = "Laticínio", ID = 5 };
            var objItemMilho = new Item() { Descricao = "Milho Enlatado", Quantidade = 1, UnidadeQtd = "Lata", Classificacao = "Enlatado", ID = 6 };
              
            // andar 0 - Charcutaria, Carnes e Ovos
            var objItemPresunto = new Item() { Descricao = "Presunto", Quantidade = 100, UnidadeQtd = "Gramas", Classificacao = "Charcutaria", ID = 7 };
            var objItemOvos = new Item() { Descricao = "Ovos", Quantidade = 1, UnidadeQtd = "Duzia", Classificacao = "Ovo", ID = 8 };
            var objItemCarne = new Item() { Descricao = "Carne", Quantidade = 1, UnidadeQtd = "Kilo", Classificacao = "Carne", ID = 9 };

            lstgeladeira = new List<Item>() 
            { 
                objItemBanana, objItemBanana, objItemLaranja, objItemLeite, objItemQueijo, objItemMilho, 
                objItemPresunto, objItemOvos, objItemCarne, objItemCarne
            };
        }


        [HttpGet]
        public IEnumerable<Item> Get() => lstgeladeira;


        [HttpHead]
        public List<Item> Head() => lstgeladeira;

        

        [HttpGet("{id}")]
        public Item Get(int id)
        {
            foreach (var item in lstgeladeira)
            {
                if (item.ID == id)
                    return item;
            }
            return new Item();
        }

        [HttpOptions]
        public Item Option(int id)
        {
            foreach (var item in lstgeladeira)
            {
                if (item.ID == id)
                    return item;
            }
            return new Item();
        }

        [HttpPatch("Alterar Descrição Item")]
        public List<Item> Patch(int id, [FromBody] string descricao, int qtde, string unidade, string classificacao)
        {
            foreach (var item in lstgeladeira)
            {
                if (item.ID == id)
                {
                    //DisplayName("Teste");                 
                    item.Descricao = descricao;
                    item.UnidadeQtd = unidade;
                    item.Quantidade = qtde;
                    item.Classificacao = classificacao;
                }

            }
            return lstgeladeira;
        }

        [HttpPost]
        public List<Item> Post([FromBody] Item item)
        {
            lstgeladeira.Add(item);

            return lstgeladeira;
        }

        [HttpPut("Alterar Descrição Item")]
        public List<Item> Put(int id, string descricao)
        {
            foreach (var item in lstgeladeira)
            {
                if (item.ID == id)
                {                                   
                    item.Descricao = descricao;
                }
                    
            }

            return lstgeladeira;
        }

        [HttpDelete("Excluir um item")]
        public List<Item> Delete(int id)
        {
            try
            {
                foreach (var item in lstgeladeira)
                {
                    if (item.ID == id)
                    {
                        lstgeladeira.Remove(item);
                        break;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstgeladeira;
        }         

    }

}

    

