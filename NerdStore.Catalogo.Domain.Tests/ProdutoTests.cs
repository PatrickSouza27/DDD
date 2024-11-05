using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.Entities.ValuesObjects;
using NerdStore.Core;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Tests;

[TestClass]
public class ProdutoTests
{
    [TestMethod]
    public void devera_verificar_se_nome_eh_vazio()
    {
        // Arrange & Act

        var ex = Assert.ThrowsException<DomainException>(() => new Produto("", "Descrição", true, 100, Guid.NewGuid(), DateTime.Now, "image.png", 10, new Dimensoes(1, 1, 1)));


        Assert.AreEqual(ex.Message, "O nome do produto não pode ser vazio");

    }
    
    // [Fact] // com Xunit
    // public void devera_verificar_se_nome_eh_vazio()
    // {
    //     // Arrange & Act
    //     var ex = Assert.Throws<DomainException>(() => new Produto("", "Descrição", true, 100, Guid.NewGuid(), DateTime.Now, "image.png", 10, new Dimensoes(1, 1, 1)));
    //
    //     // Assert
    //     Assert.Equal("O nome do produto não pode ser vazio", ex.Message);
    // }
}