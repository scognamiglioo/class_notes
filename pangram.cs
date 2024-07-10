using System;
using System.Text.RegularExpressions;

class EhPangram
{
    protected string Alfabeto { get; set; }

    public EhPangram(string alfabeto)
    {
        Alfabeto = alfabeto;
    }

    public bool IsPangram(string texto)
    {
        texto = RemoverNaoLetras(texto.ToLower());

        foreach (char letra in Alfabeto)
        {
            if (!texto.Contains(letra))
            {
                return false;
            }
        }

        return true;
    }

    private string RemoverNaoLetras(string texto)
    {
        // usando regex para remover caracteres 
        return Regex.Replace(texto, @"[^a-z]", "");
    }
}

class IsIngles : EhPangram
{
    public IsIngles() : base("abcdefghijklmnopqrstuvwxyz") { }
}

class EhPortugues : EhPangram
{
    public EhPortugues() : base("abcdefghijlmnopqrstuvxz") { }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Deseja verificar o pangrama em qual língua? \n(1 - Inglês, 2 - Português)");
        string? opcaoString = Console.ReadLine();
        if (!int.TryParse(opcaoString, out int opcao))
        {
            Console.WriteLine("Opção inválida");
            return;
        }

        Console.WriteLine("Digite a frase:");
        string? texto = Console.ReadLine(); // ? para aceitar null
        if (string.IsNullOrWhiteSpace(texto))
        {
            Console.WriteLine("Frase inválida.");
            return;
        }

        EhPangram pangram;
        if (opcao == 1)
        {
            pangram = new IsIngles();
        }
        else if (opcao == 2)
        {
            pangram = new EhPortugues();
        }
        else
        {
            Console.WriteLine("Opção inválida");
            return;
        }

        bool resultado = pangram.IsPangram(texto);

        if (resultado)
        {
            Console.WriteLine("É um pangrama");
        }
        else
        {
            Console.WriteLine("Não é um pangrama");
        }
    }
}
