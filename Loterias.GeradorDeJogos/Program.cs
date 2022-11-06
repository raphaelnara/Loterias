using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Loterias.GeradorDeJogos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    var pastaResultado = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resultado");
                    if (!Directory.Exists(pastaResultado)) Directory.CreateDirectory(pastaResultado);

                    // Modo de inserção de números
                    string resposta;
                    do
                    {
                        Console.WriteLine("Qual técnica de geração de jogo você deseja utilizar?");
                        Console.WriteLine("1 - Desdobramento");
                        Console.WriteLine("2 - Fechamento");
                        resposta = Console.ReadLine();
                    } while (!resposta.Equals("1") && !resposta.Equals("2"));

                    // Execução da técnica
                    switch (resposta.Trim())
                    {
                        case "1":
                            Desdobramento(pastaResultado);
                            break;
                        case "2":
                            Fechamento(pastaResultado);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO --->{ex}");
                }
            }
        }
        private static void Desdobramento(string pastaResultado, string[] historicoSorteados = null)
        {
            // Lê tamanho do conjunto 
            var tamanhoConjunto = LerTamanhoConjunto();

            // Lê tamanho dos subconjuntos
            var tamanhoSubconjunto = LerTamanhoSubconjunto(tamanhoConjunto);

            // Lê números do conjunto
            var numeros = LerNumerosConjunto(tamanhoConjunto);

            // Calcula total de combinações
            var totalCombinacoes = CalculaTotalCombinacoes(tamanhoConjunto, tamanhoSubconjunto);
            Console.WriteLine($"Total de combinações geradas: {totalCombinacoes} subconjuntos");

            // Cria combinações e escreve no arquivo
            var arquivoSaida = Path.Combine(pastaResultado, $"Desdobramento_{DateTime.Now:yyyyMMddHHmmss}.csv");
            using (var writer = new StreamWriter(arquivoSaida))
            {
                foreach (var combinacao in GerarCombinacoes(numeros, tamanhoSubconjunto))
                {
                    // TODO: Excluir já sorteados

                    var linha = string.Join(";", combinacao);
                    writer.WriteLine(linha);
                }
            }
            Console.WriteLine($"Arquivo CSV gerado em {arquivoSaida}");
            Process.Start(arquivoSaida);
        }

        private static void Fechamento(string pastaResultado, string[] historicoSorteados = null)
        {
            bool invalido;

            // Lê tamanho do jogo final
            int tamanhoJogoFinal;
            do
            {
                Console.WriteLine("Digite o tamanho do jogo final:");
                invalido = !int.TryParse(Console.ReadLine(), out tamanhoJogoFinal) || tamanhoJogoFinal <= 1;
                if (invalido) Console.WriteLine($"Tamanho inválido! Digite um número maior que 1 e menor que {tamanhoJogoFinal - 1}");
            } while (invalido);

            // Lê tamanho do conjunto fixo
            int tamanhoNumerosFixos;
            do
            {
                Console.WriteLine("Digite o total de números fixos:");
                invalido = !int.TryParse(Console.ReadLine(), out tamanhoNumerosFixos)
                    || tamanhoNumerosFixos <= 1
                    || tamanhoNumerosFixos > tamanhoJogoFinal - 2;
                if (invalido) Console.WriteLine($"Tamanho inválido! Digite um número maior que 1 e menor que {tamanhoJogoFinal - 1}");
            } while (invalido);

            // Lê números fixos
            var numerosFixos = LerNumerosConjunto(tamanhoNumerosFixos, "conjunto de números fixos");

            // Lê números a serem desdobrados
            var tamanhoSubconjunto = tamanhoJogoFinal - tamanhoNumerosFixos;
            var idNumerosDesdobramento = "conjunto de números a serem desdobrados";
            var tamanhoConjunto = LerTamanhoConjunto(idNumerosDesdobramento);
            var numerosDesdobrados = LerNumerosConjunto(tamanhoConjunto, idNumerosDesdobramento);

            // Calcula total de combinações
            var totalCombinacoes = CalculaTotalCombinacoes(tamanhoConjunto, tamanhoSubconjunto);
            Console.WriteLine($"Total de combinações geradas: {totalCombinacoes} subconjuntos");

            // Gera combinações e escreve no arquivo
            var arquivoSaida = Path.Combine(pastaResultado, $"Fechamento_{DateTime.Now:yyyyMMddHHmmss}.csv");
            using (var writer = new StreamWriter(arquivoSaida))
            {
                foreach (var combinacao in GerarCombinacoes(numerosDesdobrados, tamanhoSubconjunto))
                {
                    // TODO: Excluir já sorteados

                    writer.WriteLine(string.Join(";", numerosFixos.Concat(combinacao).OrderBy(n => n)));
                }
            }
            Console.WriteLine($"Arquivo CSV gerado em {arquivoSaida}");
            Process.Start(arquivoSaida);
        }

        private static int LerTamanhoConjunto(string identificadorConjunto = "conjunto")
        {
            string digitado;

            // Define o tamanho do conjunto
            int tamanhoConjunto;
            do
            {
                Console.WriteLine($"Digite o tamanho do {identificadorConjunto}:");
                digitado = Console.ReadLine();
                if (!int.TryParse(digitado, out tamanhoConjunto) || tamanhoConjunto <= 1)
                    Console.WriteLine($"Tamanho de {identificadorConjunto} inválido! Digite um número maior que 1");
            } while (!int.TryParse(digitado, out tamanhoConjunto) || tamanhoConjunto <= 1);

            return tamanhoConjunto;
        }

        private static int LerTamanhoSubconjunto(int tamanhoConjunto)
        {
            string digitado;

            // Define o tamanho do subconjunto
            int tamanhoSubconjunto;
            do
            {
                Console.WriteLine("Digite o tamanho dos subconjuntos gerados:");
                digitado = Console.ReadLine();
                if (!int.TryParse(digitado, out tamanhoSubconjunto)
                    || tamanhoSubconjunto <= 1
                    || tamanhoSubconjunto >= tamanhoConjunto)
                    Console.WriteLine($"Tamanho de subconjunto inválido! Digite um número maior que 1 e menor que {tamanhoConjunto}");
            } while (!int.TryParse(digitado, out tamanhoSubconjunto) || tamanhoSubconjunto <= 1 || tamanhoSubconjunto >= tamanhoConjunto);

            return tamanhoSubconjunto;
        }

        private static int[] LerNumerosConjunto(int tamanhoConjunto, string identificacaoConjunto = "conjunto")
        {
            // Modo de inserção de números
            string resposta;
            do
            {
                Console.WriteLine($"Qual a forma de inserção de números do {identificacaoConjunto}?");
                Console.WriteLine("1 - Digitação");
                Console.WriteLine("2 - Arquivo CSV");
                resposta = Console.ReadLine();
            } while (!resposta.Equals("1") && !resposta.Equals("2"));

            int[] numeros;

            if (resposta.Equals("1"))
            {
                while (true)
                {
                    Console.WriteLine($"Digite {tamanhoConjunto} números separados por ponto e vírgula:");
                    var digitacao = Console.ReadLine();
                    numeros = digitacao.Split(';').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => Convert.ToInt32(s.Trim())).ToArray();
                    if (numeros.Length == tamanhoConjunto) break;
                    Console.WriteLine($"Quantidade {numeros.Length} de números inválida! Digite {tamanhoConjunto} números.");
                }
            }
            else
            {
                string arquivoEntrada;
                while (true)
                {
                    Console.WriteLine($"Informe o arquivo CSV com os números do {identificacaoConjunto}:");
                    arquivoEntrada = Console.ReadLine();
                    if (File.Exists(arquivoEntrada))
                    {
                        using (var reader = new StreamReader(arquivoEntrada))
                        {
                            var linha = reader.ReadLine();
                            numeros = linha.Split(';').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => Convert.ToInt32(s.Trim())).ToArray();
                            if (numeros.Length == tamanhoConjunto) break;
                            Console.WriteLine($"Arquivo com quantidade de números {numeros.Length} inválida! Digite {tamanhoConjunto} números.");
                        }
                    }
                    Console.WriteLine("Caminho de arquivo inválido!");
                }
            }

            return numeros;
        }

        private static IEnumerable<int[]> GerarCombinacoes(IEnumerable<int> numeros, int tamanhoSubconjunto)
        {
            var conjunto = numeros.OrderBy(n => n).ToArray();

            var mapeamentoCombinacoes = Enumerable.Range(1, Convert.ToInt32(Math.Pow(2, conjunto.Length)) - 1)
                .Select(c => Convert.ToString(c, 2).PadLeft(conjunto.Length, '0'))
                .Where(s => s.Count(c => c == '1') == tamanhoSubconjunto)
                .ToArray();

            foreach (var mapa in mapeamentoCombinacoes)
            {
                var contador = 0;
                var array = new int[tamanhoSubconjunto];

                for (int indice = 0; indice < mapa.Length; indice++)
                    if (mapa[indice] == '1') array[contador++] = conjunto[indice];

                yield return array;
            }
        }

        private static int CalculaTotalCombinacoes(int n, int k)
        {
            var numerador = Fatorial(n);
            var denominador = Fatorial(k) * Fatorial(n - k);
            long total = numerador / denominador;
            return (int)total;
        }

        private static long Fatorial(int numero)
        {
            if (numero == 1) return 1;
            var fatorial = Fatorial(numero - 1);
            return numero * fatorial;
        }
    }
}
