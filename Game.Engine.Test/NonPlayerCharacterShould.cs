using Xunit;

namespace Game.Engine.Test
{
    public class NonPlayerCharacterShould
    {

        [Theory]
        [InlineData(0, 100)]
        [InlineData(10, 90)]
        [InlineData(101, 1)]
        //[MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        //[MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
        //[HealthDamageDataAttribute]
        public void TakeDamage(int damage, int expectedHealth)
        {
            var sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }
    }
}