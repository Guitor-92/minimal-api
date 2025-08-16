using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalApi.Dominio.DTOs;

namespace Test.Requests;

[TestClass]
public class VeiculoRequestTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var veiculoDto = new VeiculoDTO();

        // Act & Assert
        veiculoDto.Nome = "Civic";
        veiculoDto.Marca = "Honda";
        veiculoDto.Ano = 2020;

        // Assert
        Assert.AreEqual("Civic", veiculoDto.Nome);
        Assert.AreEqual("Honda", veiculoDto.Marca);
        Assert.AreEqual(2020, veiculoDto.Ano);
    }
}