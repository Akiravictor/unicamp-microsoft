using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using LinqToDB.DataProvider.SQLite;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using DataModel;
using System.Runtime;
using System.Reflection.Emit;

namespace Class1
{
    public class Exercise2
    {
        public void run()
        {
            /*
            Gere um JSON com todas as luas de Júpiter disponíveis no banco de dados, em ordem decrescente de massa, no formato:

            ```
            {
              'Moons of Jupiter': [
                {
                  "Body": "Europa",
                  "RadiusKm": 1560.8,
                  "VolumeE9Km3": 15.93,
                  "MassE21Kg": 48,
                  "SurfaceAreaKm2": 30613000,
                  "DensityGCm3": 3.013,
                  "GravityMS2": 1.316,
                  "Type": "moon of Jupiter (terrestrial)",
                  "ParentBody": "Jupiter",
                  "Discovery": "1610"
                },
                {...},
                ...
              ]
            }
            ```

            O *schema* do banco pode ser inspecionado nos arquivos
            BodiesDb.cs e AstralBody.cs. As chaves dos objetos JSON são as mesmas
            que os nomes das colunas.
            */

            var output_filepath = "../../../output/ex2output.json";

            var db = new BodiesDb(
                new LinqToDB.Configuration.LinqToDBConnectionOptionsBuilder()
                    .UseDataProvider(
                      LinqToDB.DataProvider.SQLite.SQLiteTools.GetDataProvider())
                    .UseConnectionString(
                      LinqToDB.ProviderName.SQLite,
                      "Database=Bodies;Data Source=../../../ex2data/bodies.sqlite")
                    .Build<BodiesDb>());

            var astralBody = from a in db.AstralBodies where a.ParentBody == "Jupiter" orderby a.MassE21Kg descending select a;

            var moons = new Moons
            {
                MoonsOfJupiter = astralBody.ToList()
            };

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(moons, options: jsonOptions).ToString();

            using FileStream fs = new(output_filepath, FileMode.Create, FileAccess.Write);

            using StreamWriter sw = new(fs);

            sw.Write(json);

            sw.Flush();
            sw.Close();

            fs.Close();

        }
    }

    public class Moons
    {
        [JsonPropertyName("Moons Of Jupiter")]
        public List<AstralBody> MoonsOfJupiter { get; set; }
    }
}