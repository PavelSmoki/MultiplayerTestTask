using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Player
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        
        private CancellationTokenSource _cancellationTokenSource;

        public void Init(Vector2 force)
        {
            _rb.AddForce(force, ForceMode2D.Impulse);
            _cancellationTokenSource = new CancellationTokenSource();
            Life().Forget();
        }

        private async UniTaskVoid Life()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(3f), cancellationToken: _cancellationTokenSource.Token)
                .SuppressCancellationThrow();
            if (_cancellationTokenSource.IsCancellationRequested) return;
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
                other.gameObject.GetComponent<Player>().TakeDamage();
            _cancellationTokenSource.Cancel();
            Destroy(gameObject);
        }
    }
}