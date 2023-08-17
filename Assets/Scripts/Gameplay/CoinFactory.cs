using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    [UsedImplicitly]
    public class CoinFactory
    {
        private const float HorizontalBorder = 23f;
        private const float VerticalBorder = 12f;

        private readonly GameObject _coinPrefab;

        public CoinFactory([Inject(Id = "Coin")] GameObject coinPrefab)
        {
            _coinPrefab = coinPrefab;
        }

        public void Create()
        {
            Object.Instantiate(_coinPrefab, new Vector3(
                Random.Range(-HorizontalBorder, HorizontalBorder),
                Random.Range(-VerticalBorder, VerticalBorder)), 
                Quaternion.identity);
        }
    }
}