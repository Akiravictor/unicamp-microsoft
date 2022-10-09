using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class2
{
	public class Ex4
	{

		// Implemente a versão paralela da função sequential_mergesort.
		// Para este exercício, pontos serão deduzidos se o resultado levar mais
		// tempo para computar do que a versão sequencial.

		// Dicas:
		// Não criar uma quantidade excessiva de tasks. Tentar criar tasks apenas
		// quando o tamanho do problema for grande.
		// Rodar com `dotnet run --configuration Release` para melhor desempenho

		static void merge(int[] list, int l, int m, int r, int[] scratch)
		{
			var left_index = l;
			var right_index = m;
			var tmp_index = l;
			while (left_index < m && right_index < r)
			{
				if (list[left_index] <= list[right_index])
					scratch[tmp_index++] = list[left_index++];
				else
					scratch[tmp_index++] = list[right_index++];
			}
			while (left_index < m) scratch[tmp_index++] = list[left_index++];
			scratch.AsSpan(l, tmp_index - l).CopyTo(list.AsSpan(l, tmp_index - l));
		}

		// Ordena a sub-string [l.r), recursivamente ordenando cada metade e depois as juntando.
		static void sequential_mergesort(int[] list, int l, int r, int[] scratch)
		{
			// Paralelize esta função.
			if (r - l <= 1)
				return;
			var m = l + (r - l + 1) / 2; // divida a array no meio.
			sequential_mergesort(list, l, m, scratch); // ordene de l a m-1
			sequential_mergesort(list, m, r, scratch); // ordene de m a r-1
			merge(list, l, m, r, scratch); // combine as duas metades
		}

		public static void parallel_mergesort(int[] list, int l, int r, int[] scratch)
		{
			// Paralelize esta função.
			if (r - l <= 1)
				return;
			var m = l + (r - l + 1) / 2; // divida a array no meio.

			var task1 = Task.Run(() => {
				sequential_mergesort(list, l, m, scratch); // ordene de l a m-1
			});

			var task2 = Task.Run(() => { 
				sequential_mergesort(list, m, r, scratch); // ordene de m a r-1
			});	

			task1.Wait();
			task2.Wait();

			merge(list, l, m, r, scratch); // combine as duas metades
		}

		static public void run()
		{

			// Carregue a versão não ordenada do arquivo.
			var unsorted_text = System.IO.File.ReadLines("../../../ex4data/unsorted_ints.txt");
			var unsorted_ints = new List<Int32>();
			foreach (var line in unsorted_text)
			{
				var x = Int32.Parse(line);
				unsorted_ints.Add(x);
			}

			var sequential_ints = unsorted_ints.ToArray();
			var parallel_ints = unsorted_ints.ToArray();
			var scratch = new int[unsorted_ints.Count];

			// Medir tempo para mergesort sequencial.

			Console.WriteLine("Start sequential mergesort.");
			var sw = new System.Diagnostics.Stopwatch();
			sw.Start();

			sequential_mergesort(sequential_ints, 0, parallel_ints.Length, scratch);

			sw.Stop();
			var sequential_time = sw.ElapsedMilliseconds;
			Console.WriteLine("Sequential mergesort: {0}ms", sequential_time);

			// Garantir que está correta.
			for (int i = 1; i < sequential_ints.Length; i++)
				System.Diagnostics.Debug.Assert(sequential_ints[i - 1] <= sequential_ints[i]);

			Console.WriteLine("Start parallel mergesort.");
			// Medir tempo para mergesort paralelo.
			sw.Restart();

			parallel_mergesort(parallel_ints, 0, parallel_ints.Length, scratch);

			sw.Stop();
			var parallel_time = sw.ElapsedMilliseconds;
			Console.WriteLine("Parallel mergesort: {0}ms", parallel_time);

			// Garantir que está correta.
			for (int i = 1; i < parallel_ints.Length; i++)
			{
				System.Diagnostics.Debug.Assert(parallel_ints[i - 1] <= parallel_ints[i]);
			}
			Console.WriteLine("Speedup: {0}x", (float)sequential_time / (float)parallel_time);
		}
	}
}