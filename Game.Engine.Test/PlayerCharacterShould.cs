using System;
using System.Collections.Generic;
using Xunit;

namespace Game.Engine.Test
{
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter _sut;
        public PlayerCharacterShould()
        {
            _sut = new PlayerCharacter();
        }
        public void Dispose()
        {
            //clean
        }

        #region Boolean Tests

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            var sut = new PlayerCharacter();

            Assert.True(sut.IsNoob);
        }

        #endregion Boolean Tests

        #region String Tests

        [Fact]
        public void CalculateFullName()
        {
            var sut = new PlayerCharacter();
            sut.FirstName = "Lion";
            sut.LastName = "King";

            Assert.Equal("Lion King", sut.FullName);
            Assert.Equal("lion king", sut.FullName, ignoreCase:true);
            Assert.EndsWith("King", sut.FullName);
            Assert.StartsWith("Lion", sut.FullName);
            Assert.Contains("on K", sut.FullName);
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", sut.FullName);
        }

        #endregion String Tests

        #region Range Tests

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            var sut = new PlayerCharacter();
            sut.Sleep();

            Assert.True(sut.Health>= 101 && sut.Health <= 200);
            //Assert.True(sut.Health is >= 101 and <= 200); //the same C# 9
            Assert.InRange(sut.Health, 101, 200); //better
        }

        #endregion Range Tests

        #region Equal Tests

        [Fact]
        public void StartWithDefaultHealth()
        {
            var sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
            Assert.NotEqual(0, sut.Health);
        }

        #endregion Equal Tests

        #region Null Tests

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            var sut = new PlayerCharacter();
        
            //Assert.NotNull(sut.NickName); //fail
            Assert.Null(sut.NickName);
        }

        #endregion Null Tests

        #region Collection Tests

        [Fact]
        public void HaveALongBow()
        {
            var sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void NotHaveWeapon()
        {
            var sut = new PlayerCharacter();

            Assert.DoesNotContain("Sword", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKingOfSword()
        {
            var sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var sut = new PlayerCharacter();
            var expectedWeapons = new List<string>
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };
            Assert.Equal(expectedWeapons, sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            var sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        #endregion Collection Tests

        #region Raise Events Tests

        [Fact]
        public void RaiseSleptEvent()
        {
            var sut = new PlayerCharacter();

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }

        [Fact]
        public void RaisePropertychangeEvent()
        {
            var sut = new PlayerCharacter();

            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }

        #endregion Raise Events Tests

        #region Data driven Tests

        // [Fact]
        // public void TakeZeroDamage()
        // {
        //     _sut.TakeDamage(0);
        //
        //     Assert.Equal(100, _sut.Health);
        // }
        //
        // [Fact]
        // public void TakeSmallDamage()
        // {
        //     _sut.TakeDamage(10);
        //
        //     Assert.Equal(90, _sut.Health);
        // }

        [Fact]
        public void HaveMinimum1Health()
        {
            _sut.TakeDamage(101);

            Assert.Equal(1, _sut.Health);
        }

        [Theory]
        [InlineData(0, 100)]
        [InlineData(10, 90)]
        [InlineData(101, 1)]
        //[MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        //[MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
        //[HealthDamageDataAttribute]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, _sut.Health);
        }
        #endregion Data driven Tests
    }
}