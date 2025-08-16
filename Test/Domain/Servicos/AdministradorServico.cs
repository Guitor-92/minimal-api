using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }

    [TestInitialize]
    public void LimparBancoDeDados()
    {
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("SET FOREIGN_KEY_CHECKS = 0;");
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE administradores");
        context.Database.ExecuteSqlRaw("ALTER TABLE administradores AUTO_INCREMENT = 1");
        context.Database.ExecuteSqlRaw("SET FOREIGN_KEY_CHECKS = 1;");
        context.SaveChanges();
    }

    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
    // Arrange
    var context = CriarContextoDeTeste();
    context.Database.ExecuteSqlRaw("DELETE FROM Administradores");
    context.SaveChanges();

    var adm = new Administrador
    {
        Email = "teste@teste.com",
        Senha = "teste",
        Perfil = "Adm"
    };

    var administradorServico = new AdministradorServico(context);

    // Act
    administradorServico.Incluir(adm);

    // Assert
    var administradores = administradorServico.Todos(1).ToList();
    Assert.IsTrue(administradores.Any(a => a.Email == "teste@teste.com"));
}

    [TestMethod]
    public void TestandoBuscaPorId()
    {
    // Arrange
    var context = CriarContextoDeTeste();
    context.Database.ExecuteSqlRaw("DELETE FROM Administradores");
    context.SaveChanges();

    var adm = new Administrador
    {
        Email = "teste@teste.com",
        Senha = "teste",
        Perfil = "Adm"
    };

    var administradorServico = new AdministradorServico(context);

    // Act
    administradorServico.Incluir(adm);

    var admDoBanco = administradorServico.BuscaPorId(adm.Id);

    // Assert
    Assert.IsNotNull(admDoBanco);
    Assert.AreEqual(adm.Email, admDoBanco.Email);
}
}