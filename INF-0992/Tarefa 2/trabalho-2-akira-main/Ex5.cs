using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class2
{
    public class Ex5
    {
        static public void run()
        {
            // Crie um programa paralelo que lê o arquivo transactions.txt,
            // executa as transações, e imprime os valores finais corretamente.
            // Para garantir o funcionamento correto, é preciso usar um lock para
            // cada conta.

            var fileLines = File.ReadAllLines("ex5data/transactions.txt").ToList();

            var funds = new int[100];
            var transactions = new List<Transaction>();

            foreach (var line in fileLines)
            {
                if (line.Contains("INITIALFUNDS"))
                {
                    funds[int.Parse(line.Split(' ')[1])] = int.Parse(line.Split(' ')[3]);
				}

                if (line.Contains("TRANSFER"))
                {
                    transactions.Add(new Transaction
                    {
                        From = int.Parse(line.Split(' ')[3]),
                        To = int.Parse(line.Split(' ')[5]),
                        Amount = int.Parse(line.Split(' ')[1])
					});
                }
            }

            Parallel.ForEach(transactions, transaction =>
            {
                lock (funds)
                {
					funds[transaction.From] -= transaction.Amount;
					funds[transaction.To] += transaction.Amount;
                }

            });

            StringBuilder sb = new();

            for(int i = 0; i < 100; i++)
            {
                sb.AppendLine($"FUNDS {i} = {funds[i]}");
            }

            using FileStream fs = new FileStream("ex5data/transaction_results.txt", FileMode.Create);
            using StreamWriter sw = new StreamWriter(fs);

            sw.Write(sb);

            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }

    public class Transaction
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Amount { get; set; }
    }
}