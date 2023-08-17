using Game.Gameplay;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game
{
    public class BaseInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _coinPrefab;

        public override void InstallBindings()
        {
            Container.Bind<IPlayer>().FromComponentInNewPrefab(_playerPrefab).AsSingle().NonLazy();
            Container.BindInterfacesTo<GameplayController>().AsSingle().NonLazy();
            Container.Bind<CoinFactory>().AsSingle();
            Container.Bind<GameObject>().WithId("Coin").FromInstance(_coinPrefab);
        }
    }
}
