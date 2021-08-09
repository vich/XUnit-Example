﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Game.Engine.Test
{
    public class ExternalHealthDamageTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                var csvLines = File.ReadAllLines("TestData.csv");
                var testCases = new List<object[]>();

                foreach (var csvLine in csvLines)
                {
                    var values = csvLine.Split(',').Select(int.Parse);
                    var testCase = values.Cast<object>().ToArray();
                    testCases.Add(testCase);
                }

                return testCases;
            }
        }
    }
}