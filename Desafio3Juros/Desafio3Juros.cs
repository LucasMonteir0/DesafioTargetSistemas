using System.Globalization;

namespace DesafioTargetSistemas.Desafio3Juros
{
    public class Desafio3Juros
    {

        public static void Executar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Desafio 3: Calculadora de Multa e Juros por Atraso ---");
            Console.ResetColor();

            Console.Write("Digite o valor original do débito (ex: 100.00): ");
            if (!decimal.TryParse(Console.ReadLine()?.Replace(',', '.'), NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal valorOriginal) || valorOriginal <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valor original inválido.");
                Console.ResetColor();
                return;
            }

            Console.Write("Digite a data de vencimento (formato dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataVencimento))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Data de vencimento inválida.");
                Console.ResetColor();
                return;
            }

            DateTime dataHoje = DateTime.Today;

            int diasAtraso = 0;
            if (dataHoje > dataVencimento)
            {
        
                diasAtraso = (dataHoje - dataVencimento).Days;
            }

            const decimal taxaDiaria = 0.025m ;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- Detalhes do Cálculo ---");
            Console.ResetColor();
            Console.WriteLine($"Valor Original: {valorOriginal.ToString("C")}");
            Console.WriteLine($"Data de Vencimento: {dataVencimento.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Data de Cálculo (Hoje): {dataHoje.ToString("dd/MM/yyyy")}");

            if (diasAtraso <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nStatus: Pagamento dentro do prazo ou na data de vencimento.");
                Console.WriteLine($"Valor Total Devido: {valorOriginal.ToString("C")}");
            }
            else
            {
                Console.WriteLine($"Dias em Atraso (n): {diasAtraso} dia(s)");
                Console.WriteLine($"Taxa de Juros Composta (r): {taxaDiaria:P1} ao dia");

                double fatorMultiplicativo = Math.Pow((double)(1m + taxaDiaria), diasAtraso);

                decimal montanteTotal = valorOriginal * (decimal)fatorMultiplicativo;

                decimal valorJuros = montanteTotal - valorOriginal;

                Console.WriteLine($"Juros Compostos Acumulados: {valorJuros.ToString("C")}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nValor Total Devido (Montante): {montanteTotal.ToString("C")}");
            }


            Console.ResetColor();
        }
    
}
}