angular.module('deliveryApp').factory('carrinhoSharedService', function(){
	var carrinhoSharedService = {
		novoItemCarrinho: false,
		valorPedido: 0,
		itensPedido: [],
		calcularValorPedido: function(){
			this.valorPedido = 0;
			for(i = 0; i < this.itensPedido.length; i++){
				this.valorPedido += this.itensPedido[i].quantidade * this.itensPedido[i].produto.PRECO;
			}
			
		},
		adicionar: function(itemPedido){
			this.novoItemCarrinho = false;
			var existe = false;
			for (i = 0; i < this.itensPedido.length; i++) {
		        if (this.itensPedido[i].produto.NOME == itemPedido.produto.NOME) {
		     		this.itensPedido[i].quantidade += itemPedido.quantidade;
		     		existe = true;
		        }
		    }
		    if(!existe){
				this.itensPedido.push(itemPedido);
			}
			this.novoItemCarrinho = true;
			this.calcularValorPedido();
		}, 
		excluir: function(item){
			this.itensPedido = this.itensPedido.filter(function (itemPedido){
		        if (itemPedido.produto.NOME != item.produto.NOME) {
		     		return itemPedido;
		        }
			});
			this.calcularValorPedido();
		},
		aumentarQuantidade: function(itemPedido){
			for (i = 0; i < this.itensPedido.length; i++) {
		        if (this.itensPedido[i].produto.NOME == itemPedido.produto.NOME) {
		     		this.itensPedido[i].quantidade += 1;
		        }
		    };
		    this.calcularValorPedido();
		},
		diminuirQuantidade: function(itemPedido){
			for (i = 0; i < this.itensPedido.length; i++) {
		        if (this.itensPedido[i].produto.NOME == itemPedido.produto.NOME) {
		     		this.itensPedido[i].quantidade -= 1;
		     		if(this.itensPedido[i].quantidade < 1){
		     			this.itensPedido[i].quantidade = 1;
		     		}
		        }
		    };
		    this.calcularValorPedido();
		}
	};

	return carrinhoSharedService;
});