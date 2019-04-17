using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using static Lab3_Unions.ListUnionExtentions;

namespace Lab3_Unions
{
    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class  CollectionUnionManager
    {
        public const string FileFirstPath = @"Data\Barcelona1.csv";
        public const string FileSecondPath = @"Data\Barcelona2.csv";
       
        public static List<Apartment> LoadApartmentData(bool isStringId, string filePath)
        {
            var apartments = new List<Apartment>();
            using (var reader = new StreamReader(filePath))
            {
                bool isHeader = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    if (isHeader)
                    {
                        isHeader = false;
                    }
                    else
                    {


                        var values = line.Split(',');
                        if (values.Length != 8) continue;
                        int id;
                        if (isStringId)
                        {
                            id = Convert.ToInt32(values[0].Split('/').Last());
                        }
                        else
                        {
                            id = Convert.ToInt32(values[0]);
                        }

                        var app = new Apartment(id, values[1], values[2], values[3], values[4], Convert.ToDouble(values[6]), Convert.ToDouble(values[7]));
                        apartments.Add(app);
                    }

                }
            }

            return apartments;
        }
        [GlobalSetup]
        public static void InitData()
        {
            FirstApartmentsList = LoadApartmentData(false, CollectionUnionManager.FileFirstPath);
            SecondApartmentsList = LoadApartmentData(true, CollectionUnionManager.FileSecondPath);
        }

        public static List<Apartment> FirstApartmentsList { get; set; }
        public static List<Apartment> SecondApartmentsList { get; set; }
        [Benchmark]
        public void UnionCollection()
        {
            //InitData();
            FirstApartmentsList.MyUnion(SecondApartmentsList);
           // Console.WriteLine($"UNION: FirstApartmentsList count is {FirstApartmentsList.Count}");
        }
        [Benchmark]
        public void UnionAllCollection()
        {

            //InitData();
            FirstApartmentsList.MyUnionAll(SecondApartmentsList);
            //Console.WriteLine($"UNION ALL: FirstApartmentsList count is {FirstApartmentsList.Count}");
        }
    }
}
