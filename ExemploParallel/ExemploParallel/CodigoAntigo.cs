using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ExemploParallel
{
    public static class CodigoAntigo
    {
        public static void ExecuteCodigoAntigo()
        {
            Console.WriteLine("Hello World!");

            List<string> urls = new List<string>();

            for (var i = 0; i < 100; i++)
            {
                urls.Add("URL" + i);
            }

            var primeiraMetade = urls.Take(urls.Count() / 2);
            var segundaMetade = urls.Skip(urls.Count() / 2);

            Thread thread1 = new Thread(() =>
            {
                foreach (var url in primeiraMetade)
                {
                    DownloadFile(url);
                }
            });

            Thread thread2 = new Thread(() =>
            {
                foreach (var url2 in segundaMetade)
                {
                    DownloadFile(url2);
                }
            });

            thread1.Start();
            thread2.Start();

            while (thread1.IsAlive || thread2.IsAlive)
            {

            }
            //Parallel.For(0, urls.Count, i =>
            //{
            //    DownloadFile(urls[i]);
            //});

            Console.WriteLine("Jabiraba");
        }

        static void DownloadFile(string url)
        {
            Console.WriteLine("Download done " + url + " ThreadId: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}

