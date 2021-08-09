using Xunit;
using Xunit.Abstractions;

namespace Game.Engine.Test
{
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public GameStateShould(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture;
            _output = output;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            //_output.WriteLine($"{nameof(GameState)} ID={_gameStateFixture.State.Id}");
            var sut = new GameState(); //todo: remove

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            sut.Players.Add(player1);
            sut.Players.Add(player2);
            // _gameStateFixture.State.Players.Add(player1);
            // _gameStateFixture.State.Players.Add(player2);

            var expectedHealthAfterEarthquake1 = player1.Health - GameState.EarthquakeDamage;
            var expectedHealthAfterEarthquake2 = player2.Health - GameState.EarthquakeDamage;

            sut.Earthquake();
            //_gameStateFixture.State.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake1, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake2, player2.Health);
        }


        [Fact]
        public void Reset()
        {
            //_output.WriteLine($"{nameof(GameState)} ID={_gameStateFixture.State.Id}");
            var sut = new GameState(); //todo: remove

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            sut.Players.Add(player1);
            sut.Players.Add(player2);
            // _gameStateFixture.State.Players.Add(player1);
            // _gameStateFixture.State.Players.Add(player2);

            sut.Reset();
            // _gameStateFixture.State.Reset();

            Assert.Empty(sut.Players);
            //Assert.Empty(_gameStateFixture.State.Players);
        }
    }
}