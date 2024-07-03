using System;



class EhPangram
{
    public bool IsPangram(string texto)
    {
        if (string.IsNullOrEmpty(texto) || texto.Length < 26)
        {
            
            return false; // se não estiver presente, a frase não é um pangrama
        }

        for (char letra = 'a'; letra <= 'z'; letra++) // percorre o alfabeto de 'a' a 'z' para verificar se todas as letras estão presentes e contador de 26 letras 
        {
            if (texto.IndexOf(letra) == -1 && texto.IndexOf(char.ToUpper(letra)) == -1) // verifica se a letra está presente na frase
            {
                
                return false; // se não estiver presente, a frase não é um pangrama
            }
        }

       
        return true; // se todas as letras estiverem presentes, a frase é um pangrama
    }
}

class IsIngles : EhPangram
{
    private string phrase = string.Empty; // string.empty é uma string vazia para evitar null reference exception
    public string Phrase { get; set; } = string.Empty; // string.empty é uma string vazia para evitar null reference exception
}

class EhPortugues : EhPangram
{
    private string phrase = string.Empty; // string.empty é uma string vazia para evitar null reference exception
    public string Frase { get; set; } = string.Empty; // string.empty é uma string vazia para evitar null reference exception
}

class Program
{
    static void Main()
    {

        Console.WriteLine("Deseja verificar o pangrama em qual lingua? \n(1 - Inglês, 2 - Português)");
        string? opcaostring = Console.ReadLine();
        if (!int.TryParse(opcaostring, out int opcao))
        {
            Console.WriteLine("Opção inválida");
            return;
        }

        Console.WriteLine("Digite a frase:");
        string? texto = Console.ReadLine(); // ? para aceitar null
        EhPangram pangram = new EhPangram();
       
        bool resultado;

        if (opcao == 1)
        {
            IsIngles ingles = new IsIngles();
            ingles.Phrase = texto ?? string.Empty;
            resultado = ingles.IsPangram(ingles.Phrase);
        }
        else if (opcao == 2)
        {
            EhPortugues portugues = new EhPortugues();
            portugues.Frase = texto ?? string.Empty;
            resultado = portugues.IsPangram(portugues.Frase);
        }
        else
        {
            Console.WriteLine("Opção inválida");
            return;
        }

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


/* A tarefa é determinar se uma sentença é um pangrama. Um pangrama é uma sentença que utiliza cada letra do alfabeto pelo menos uma vez. É insensível a maiúsculas e minúsculas.

 O programa deve solicitar ao usuário se ele deseja usar em Inglês ou Português. Deverá ter uma classe base com os atributos/métodos comuns e duas classes derivadas especializadas para a tarefa em cada idioma.  Poderá ser em dupla.

Entrada
Inglês
The quick brown fox jumps over the 2 lazy dog

Saída 
É um pangrama

Entrada
Português
Gazeta publica hoje: breve anuncio de faxina na quermesse

Saída 
É um pangrama

Entrada
Português
Esta_frase nao usa todas as letras, estao faltando algumas

Saída 
Não é um pangrama */