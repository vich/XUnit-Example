using System.Collections.Generic;

namespace Game.Engine.Test
{
    public class InternalHealthDamageTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 0, 100 };
                yield return new object[] { 10, 90 };
                yield return new object[] { 101, 1 };
            }
        }
    }
}