using System;
using Xunit;

namespace Game.Engine.Test
{

    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        #region Assert Types Tests

        //[Fact(Skip = "Don't need to run this")]
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            var sut = new EnemyFactory();

            var enemy = sut.Create("Good Guy");

            Assert.IsType<NormalEnemy>(enemy);
            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            var sut = new EnemyFactory();

            var enemy = sut.Create("King", true);

            BossEnemy boss = Assert.IsType<BossEnemy>(enemy); //return the type
            Assert.IsNotType<NormalEnemy>(enemy);

            Assert.Equal("King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            var sut = new EnemyFactory();

            var enemy = sut.Create("King", true);

            //Assert.IsType<Enemy>(enemy); //fail
            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        #endregion Assert Types Tests

        #region Assert Object Instances

        [Fact]
        public void CreateSeparateInstances()
        {
            var sut = new EnemyFactory();

            var enemy1 = sut.Create("Enemy");
            var enemy2 = sut.Create("Enemy");

            Assert.NotSame(enemy1, enemy2);
            //Assert.Same(enemy1, enemy2); //fail
        }

        #endregion Assert Object Instances

        #region Exception Tests

        [Fact]
        public void NotAllowNullName()
        {
            var sut = new EnemyFactory();

            Assert.Throws<ArgumentNullException>(() => sut.Create(null)); 
            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null)); 
            //Assert.Throws<ArgumentNullException>("isBoss", () => sut.Create(null)); //fail
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            var sut = new EnemyFactory();

            Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));
        }

        #endregion Exception Tests
    }
}