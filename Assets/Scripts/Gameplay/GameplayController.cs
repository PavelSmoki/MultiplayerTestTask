using JetBrains.Annotations;
using Zenject;

namespace Game.Gameplay
{
    [UsedImplicitly]
    public class GameplayController : IInitializable
    {
        private readonly CoinFactory _coinFactory;

        public GameplayController(CoinFactory coinFactory)
        {
            _coinFactory = coinFactory;
        }

        public void Initialize()
        {
            for (var i = 0; i < 5; i++)
            {
                _coinFactory.Create();
            }
        }
    }
}