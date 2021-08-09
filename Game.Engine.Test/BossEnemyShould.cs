using Xunit;
using Xunit.Abstractions;

namespace Game.Engine.Test
{
    public class BossEnemyShould
    {
        private readonly ITestOutputHelper _output;

        public BossEnemyShould(ITestOutputHelper output)
        {
            _output = output;
        }

        #region Float Point tests

        [Fact]
        [Trait("Category", "Enemy")]
        public void HaveCorrectPower()
        {
            _output.WriteLine("Creating Boss Enemy");
            var sut = new BossEnemy();

            //Assert.Equal(166.666, sut.SpecialAttackPower); //fail
            //Assert.Equal(166.666, sut.SpecialAttackPower, 3); //fail
            Assert.Equal(166.667, sut.SpecialAttackPower, 3); //success 

        }

        #endregion Float Point tests
    }
}