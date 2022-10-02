using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class2

{
  public class Ex3
  {

    static float dot_product(float[] a, float[] b)
    {
      float acc = 0;
      for (int i = 0; i < a.Length; i++)
      {
        acc += a[i] * b[i];
      }
      return acc;
    }

    static float dot_product_parallel(float[] a, float[] b)
    {
      // Paralelize esta função.
      float acc = 0;
      for (int i = 0; i < a.Length; i++)
      {
        acc += a[i] * b[i];
      }
      return acc;
    }

    public static void run()
    {
      // Calcule e imprima o produto interno dos vetores A e B.
      // A versão sequencial já está disponível. Crie uma versão paralela.
      // Para esse exercício, o resultado não precisa ser mais rápido que a versão sequencial.

      var vetor_a = File.ReadAllLines("ex3data/vetor_a.txt").Select((x) => float.Parse(x)).ToArray();
      var vetor_b = File.ReadAllLines("ex3data/vetor_b.txt").Select((x) => float.Parse(x)).ToArray();

      var sw = new System.Diagnostics.Stopwatch();
      sw.Start();

      var result_1 = dot_product(vetor_a, vetor_b);

      sw.Stop();

      var seq_time = sw.Elapsed.TotalMilliseconds;

      Console.WriteLine("Resultado sequencial: {0} Tempo: {1}ms", result_1, seq_time);

      sw.Restart();

      var result_2 = dot_product_parallel(vetor_a, vetor_b);

      sw.Stop();
      var par_time = sw.Elapsed.TotalMilliseconds;

      Console.WriteLine("Resultado paralelo: {0}  Tempo: {1}ms", result_2, par_time);

      System.Diagnostics.Debug.Assert(par_time != 0.0);

      Console.WriteLine("Speedup: {0}", (float)seq_time / (float)par_time);

    }
  }
}