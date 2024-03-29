﻿
using System;

class Program
{
    static void Main(string[] args)
    {
        
                int num1, num2;

                Console.WriteLine("Digite o primeiro número: ");
                string a = Console.ReadLine();
                bool isNum1Valid = int.TryParse(a, out num1);

                Console.WriteLine("Digite o segundo número: ");
                string b = Console.ReadLine();
                bool isNum2Valid = int.TryParse(b, out num2);

                if (isNum1Valid && isNum2Valid)
                {

                Console.WriteLine("A soma dos números é: " + (num1 + num2));
                Console.WriteLine("A subtração dos números é: " + (num1 - num2));
                Console.WriteLine("A multiplicação dos números é: " + (num1 * num2));
                Console.WriteLine("A divisão dos números é: " + (num1 / num2));
                Console.WriteLine("O resto da divisão dos números é: " + (num1 % num2));
                }
                else
                {
                    Console.WriteLine("Os números digitados não são válidos.");
                }
            }
        }

// lambda
        Console.Write("Digite o primeiro número: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o segundo número: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Func<int, int, (int ad, int sub, int mult, int div,int rest)> all =
            (x, y) => ((x + y), (x - y), (x * y), (x / y),(x%y));
        
        var result = all(num1, num2); 
        Console.WriteLine($"Soma: {result.ad}");
        Console.WriteLine($"Subtração: {result.sub}");
        Console.WriteLine($"Multiplicação: {result.mult}");
        Console.WriteLine($"Divisão: {result.div}");
        Console.WriteLine($"Resto: {result.rest}");


