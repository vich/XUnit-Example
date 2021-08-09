using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Game.Engine.Test
{
    public class HealthDamageDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0, 100 };
            yield return new object[] { 10, 90 };
            yield return new object[] { 101, 1 };

            //can work with external data too
            // var csvLines = File.ReadAllLines("TestData.csv");
            // var testCases = new List<object[]>();
            //
            // foreach (var csvLine in csvLines)
            // {
            //     var values = csvLine.Split(',').Select(int.Parse);
            //     var testCase = values.Cast<object>().ToArray();
            //     testCases.Add(testCase);
            // }
            //
            // return testCases;
        }
    }
}