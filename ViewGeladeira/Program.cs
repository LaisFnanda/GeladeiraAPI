using Domain.Models;

Item objItem = new();
Geladeira objGeladeira = new Geladeira();
Container objContainer = new Container();

//Conceito de pilha- Stack

// andar 2 - Hortifrutis
var objItemMaca = new Item() { DescricaoItem = "Maçã", Quantidade = 1, UnidadeQtd = "Unidade", Classificacao = "Fruta", IdItem = 1 };
var objItemBanana = new Item() { DescricaoItem = "Banana", Quantidade = 1, UnidadeQtd = "Cacho", Classificacao = "Fruta", IdItem = 2 };
var objItemLaranja = new Item() { DescricaoItem = "Laranja", Quantidade = 1, UnidadeQtd = "Duzia", Classificacao = "Fruta", IdItem = 3 };


objItem.AdicionarItem(2, 0, 0, objItemMaca);
objItem.AdicionarItem(2, 0, 1, objItemBanana);
objItem.AdicionarItem(2, 1, 2, objItemLaranja);

// andar 1 - Laticínios e Enlatados
var objItemLeite = new Item() { DescricaoItem = "Leite", Quantidade = 1, UnidadeQtd = "Litro", Classificacao = "Laticínio", IdItem = 4 };
var objItemQueijo = new Item() { DescricaoItem = "Queijo", Quantidade = 1, UnidadeQtd = "Unidade", Classificacao = "Laticínio", IdItem = 5 };
var objItemMilho = new Item() { DescricaoItem = "Milho Enlatado", Quantidade = 1, UnidadeQtd = "Lata", Classificacao = "Enlatado", IdItem = 6 };

objItem.AdicionarItem(1, 0, 0, objItemLeite);
objItem.AdicionarItem(1, 1, 1, objItemQueijo);
objItem.AdicionarItem(1, 1, 2, objItemMilho);

// andar 0 - Charcutaria, Carnes e Ovos
var objItemPresunto = new Item() { DescricaoItem = "Presunto", Quantidade = 100, UnidadeQtd = "Gramas", Classificacao = "Charcutaria", IdItem = 7 };
var objItemOvos = new Item() { DescricaoItem = "Ovos", Quantidade = 1, UnidadeQtd = "Duzia", Classificacao = "Ovo", IdItem = 8 };
var objItemCarne = new Item() { DescricaoItem = "Carne", Quantidade = 1, UnidadeQtd = "Kilo", Classificacao = "Carne", IdItem = 9 };

objItem.AdicionarItem(0, 0, 0, objItemPresunto);
objItem.AdicionarItem(0, 0, 1, objItemOvos);
objItem.AdicionarItem(0, 1, 3, objItemCarne);

// mostrar itens no console
objGeladeira.ImprimeGeladeira() ;

objItem.RemoverItem(2, 0, 3);

// Remove um item
objItem.RemoverItem(2, 0, 1);

// adicona um item numa posicao ocupada 
var objItemPera = new Item() { DescricaoItem = "Pera", Quantidade = 1, UnidadeQtd = "Unidade", Classificacao = "Fruta", IdItem = 10 };
objItem.AdicionarItem(2, 0, 1, objItemPera);

// limpa o container
objContainer.LimparContainer(1, 1);

// adiciona varios itens no container
var objItemIogurte = new Item() { DescricaoItem = "Iogurte", Quantidade = 300, UnidadeQtd = "ML", Classificacao = "Laticínio", IdItem = 11 };
var objItemManteiga = new Item() { DescricaoItem = "Manteiga", Quantidade = 300, UnidadeQtd = "Gramas", Classificacao = "Laticínio", IdItem = 12 };
var objItemCafe = new Item() { DescricaoItem = "Café", Quantidade = 100, UnidadeQtd = "Gramas", Classificacao = "Enlatado", IdItem = 13 };

objItem.AddItens (1, 0, new List<Item> { objItemIogurte, objItemManteiga, objItemCafe });

// adiciona itens a mais que a o container pode suportar
var objItemCha = new Item() { DescricaoItem = "Ervilha", Quantidade = 100, UnidadeQtd = "Gramas", Classificacao = "Enlatado", IdItem = 14 };
var objItemMel = new Item() { DescricaoItem = "Mel", Quantidade = 100, UnidadeQtd = "Gramas", Classificacao = "Enlatados", IdItem = 15 };
var objItemPao = new Item() { DescricaoItem = "Pão", Quantidade = 3, UnidadeQtd = "Unidades", Classificacao = "Padaria", IdItem = 16 };
var objItemCeral = new Item() { DescricaoItem = "Cereal", Quantidade = 300, UnidadeQtd = "Gramas", Classificacao = "Elatado", IdItem = 17 };
var objItemGranola = new Item() { DescricaoItem = "Granola", Quantidade = 100, UnidadeQtd = "Gramas", Classificacao = "Enlatado", IdItem = 18 };

objItem.AddItens (1, 0, new List<Item> { objItemCha, objItemMel, objItemPao, objItemCeral, objItemGranola });

// mostra itens no console
objGeladeira.ImprimeGeladeira();