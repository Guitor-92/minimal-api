using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;

namespace Test.Mocks;

public class VeiculoServicoMock : IVeiculoServico
{
    private static List<Veiculo> veiculos = new List<Veiculo>(){
        new Veiculo{
            Id = 1,
            Nome = "Civic",
            Marca = "Honda",
            Ano = 2020
        },
        new Veiculo{
            Id = 2,
            Nome = "Corolla",
            Marca = "Toyota", 
            Ano = 2021
        }
    };

    public void Atualizar(Veiculo veiculo)
    {
        var veiculoExistente = veiculos.Find(v => v.Id == veiculo.Id);
        if (veiculoExistente != null)
        {
            veiculoExistente.Nome = veiculo.Nome;
            veiculoExistente.Marca = veiculo.Marca;
            veiculoExistente.Ano = veiculo.Ano;
        }
    }

    public void Apagar(Veiculo veiculo)
    {
        veiculos.Remove(veiculo);
    }

    public Veiculo? BuscaPorId(int id)
    {
        return veiculos.Find(v => v.Id == id);
    }

    public void Incluir(Veiculo veiculo)
    {
        veiculo.Id = veiculos.Count + 1;
        veiculos.Add(veiculo);
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        return veiculos;
    }
}