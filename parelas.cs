        Console.WriteLine("Escolha uma opção: ");
        Console.WriteLine("1 - Definir parcelas");
        Console.WriteLine("2 - Sair");

        int? opcao = Convert.ToInt32(Console.ReadLine());

        while (opcao != 2)
        {
            if (opcao == 1)
            {
                Console.WriteLine("Número de meses: ");
                int meses = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Taxa de juros mensal: ");
                double juros = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Valor finaciado: ");
                double valor = Convert.ToDouble(Console.ReadLine());

                // calcular o coeficiente de financiamento 
                double coeficiente = (juros / 100) / (1 - Math.Pow(1 + (juros / 100), -meses));
                double total = valor * coeficiente;
            
                // exibir o valor da parcela com duas casas decimais
                Console.WriteLine("Valor da parcela: " + total.ToString("N2"));
                // a linguagem c# arredonda o valor da parcela para cima =, tipo 100.01 para 101.00 e pode ser feito pelo método Math.Ceiling 
                

            } else {
                Console.WriteLine("Opção inválida");
            }

            Console.WriteLine("Escolha uma opção: ");
            Console.WriteLine("1 - Definir parcelas");
            Console.WriteLine("2 - Sair");

            opcao = Convert.ToInt32(Console.ReadLine());
