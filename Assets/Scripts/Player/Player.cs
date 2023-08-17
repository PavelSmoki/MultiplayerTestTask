using UnityEngine;

namespace Game.Player
{
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private GameObject _arrow;
        [SerializeField] private GameObject _projectilePrefab;
        
        [SerializeField] private float _speed;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private float _shotSpeed;

        public int Coins { get; private set; }

        private float _timeBeforeShoot;

        void IPlayer.Move(float horizontal, float vertical)
        {
            _rb.velocity = new Vector2(horizontal * _speed, vertical * _speed);
        }
        
        void IPlayer.Shoot(Vector2 moveDirection, Vector2 lookDirection)
        {
            ShootTick();

            if (lookDirection.Equals(Vector2.zero))
            {
                RotateArrow(moveDirection);
            }
            else
            {
                RotateArrow(lookDirection);
                ShootProcessing();
            }
        }

        private void ShootTick()
        {
            if (_timeBeforeShoot > 0)
            {
                _timeBeforeShoot -= Time.deltaTime;
            }
        }
        
        private void ShootProcessing()
        {
            if (_timeBeforeShoot <= 0)
            {
                var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
                projectile.transform.rotation = _arrow.transform.rotation;
                projectile.GetComponent<Projectile>().Init(projectile.transform.up * _shotSpeed);
                _timeBeforeShoot = 1 / (_attackSpeed);
            }
        }
        
        private void RotateArrow(Vector2 direction)
        {
            var toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            _arrow.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 180);
        }

        public void TakeDamage()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                Coins++;
                Destroy(other.gameObject);
            }
        }
    }
}
