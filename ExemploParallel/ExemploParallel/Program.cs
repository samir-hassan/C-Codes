using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExemploParallel
{
    class Program
    {
        static void Main(string[] args)
        {

            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            //CodigoAntigo.ExecuteCodigoAntigo();

            var numeroConta = 1;

            var conta1 = new Conta
            {
                numeroConta = numeroConta++,
                gastoAtual = (float)GetRandomNumber(0, 999),
                gastoMesesAnteriores = GetMesesAnteriores()
            };

            var conta2 = new Conta
            {
                numeroConta = numeroConta++,
                gastoAtual = (float)GetRandomNumber(0, 999),
                gastoMesesAnteriores = GetMesesAnteriores()
            };

            var conta3 = new Conta
            {
                numeroConta = numeroConta++,
                gastoAtual = (float)GetRandomNumber(0, 999),
                gastoMesesAnteriores = GetMesesAnteriores()
            };

            var contas = new List<Conta>();

            contas.Add(conta1);
            contas.Add(conta2);
            contas.Add(conta3);

            var resultado = await ConsolidarContas(contas);

            foreach (var r in resultado)
                Console.WriteLine(r);


        }

        static async Task<string[]> ConsolidarContas(List<Conta> contas, IProgress<string> reportadorProgresso)
        {
            var tasks = contas.Select(conta =>
            {
                return Task.Factory.StartNew(() =>
                {
                    var resultado = ConsolidarConta(conta);

                    reportadorProgresso.Report(resultado);

                    return resultado;
                });
            });

            //Quando o WhenAll Espera a execuçao de uma lista de tarefas com um mesmo retorno, ele retorna uma task 
            //que retorna um Array desse mesmo retorno
            return await Task.WhenAll(tasks);
        }

        static string ConsolidarConta(Conta conta)
        {
            Thread.Sleep((int)GetRandomNumber(0, 5000));
            var gastoTotal = conta.gastoMesesAnteriores.Sum();
            return "Conta " + conta.numeroConta + " possui um gasto total de " + gastoTotal + " nos ultimos meses, ";
        }

        //gera um rangom number
        static double GetRandomNumber(double minimum, double maximum)
        {
            var random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        static List<float> GetMesesAnteriores()
        {
            var retorno = new List<float>();

            for (var i = 0; i < 12; i++)
            {
                retorno.Add((float)GetRandomNumber(0, 999));
            }

            return retorno;
        }
    }
}
