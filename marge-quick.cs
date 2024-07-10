using System;
using System.Collections.Generic; // esse using é necessário para usar List


public interface IOrdenacao
{
    List<string> Sort(List<string> lista);
}

public class QuickSort : IOrdenacao
/* o quicksort é um metodo de ordenação que divide a lista em duas partes, uma com os elementos menores que o pivô e outra com os elementos maiores que o pivô. 
depois disso, ele ordena as duas partes recursivamente. 
 */
{
    
    public List<string> Sort(List<string> lista)
    {
        if (lista.Count <= 1)
            return lista;

        List<string> menores = new List<string>();
        List<string> iguais = new List<string>(); // o pivo é classificado como igual a ele mesmo, escolhido como o elemento do meio da lista
        List<string> maiores = new List<string>();

        string pivo = lista[lista.Count / 2]; // o pivo é o elemento do meio da lista

        foreach (string item in lista)
        {
            if (string.Compare(item, pivo) < 0)
                menores.Add(item);
            else if (string.Compare(item, pivo) == 0)
                iguais.Add(item);
            else
                maiores.Add(item);
        }

        List<string> ordenada = Sort(menores);
        ordenada.AddRange(iguais);
        ordenada.AddRange(Sort(maiores));

        return ordenada;
    }
}
 


public class MargeSort : IOrdenacao
/* o mergesort é um metodo de ordenação que divide a lista em duas partes, ordena as duas partes e depois junta as duas partes ordenadas.
 */
{
    
    public List<string> Sort(List<string> lista)
    {
        if (lista.Count <= 1)
            return lista;

        int meio = lista.Count / 2; // o meio da lista é calculado
        List<string> esquerda = lista.GetRange(0, meio);
        List<string> direita = lista.GetRange(meio, lista.Count - meio);

        return Merge(Sort(esquerda), Sort(direita));
    }

    private List<string> Merge(List<string> esquerda, List<string> direita)
    {
        List<string> resultado = new List<string>();
        int i = 0, j = 0;

        while (i < esquerda.Count && j < direita.Count)
        {
            if (string.Compare(esquerda[i], direita[j]) <= 0)
            {
                resultado.Add(esquerda[i]);
                i++;
            }
            else
            {
                resultado.Add(direita[j]);
                j++;
            }
        }

        resultado.AddRange(esquerda.GetRange(i, esquerda.Count - i));
        resultado.AddRange(direita.GetRange(j, direita.Count - j));

        return resultado;
    }
}


public class ListaOrdenada
{
    private List<string> lista;
    private IOrdenacao estrategiaOrdenacao;

    public ListaOrdenada(List<string> lista, IOrdenacao estrategia)
    {
        this.lista = lista;
        this.estrategiaOrdenacao = estrategia;
    }

    public void SetEstrategia(IOrdenacao estrategia)
    {
        this.estrategiaOrdenacao = estrategia;
    }

    public void Sort()
    {
        lista = estrategiaOrdenacao.Sort(lista);
        foreach (string nome in lista)
        {
            Console.WriteLine(nome);
        }
    }
}


class Program
{
    static void Main()
    {
        List<string> lista = new List<string> { "Hamlin", "Hocevar", "Bell", "Truex Jr.", "Ty Gibbs" };

        ListaOrdenada listaOrdenada = new ListaOrdenada(lista, new QuickSort());
        Console.WriteLine("QuickSort:");
        listaOrdenada.Sort();

        listaOrdenada.SetEstrategia(new MargeSort());
        Console.WriteLine("\nMargeSort:");
        listaOrdenada.Sort();
    }
}
