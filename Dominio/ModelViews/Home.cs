namespace MinimalApi.Dominio.ModelViews;

public struct Home
{
    public readonly string Mensagem { get => "Bem-vindo à API de veículos - Minimal API"; }
    public string Doc { get => "/swagger"; }
}