using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _moveJoystick;
        [SerializeField] private FloatingJoystick _lookJoystick;
        
        private IPlayer _player;

        [Inject]
        private void Construct(IPlayer player)
        {
            _player = player;
        }

        private void FixedUpdate()
        {
            _player.Move(_moveJoystick.Horizontal, _moveJoystick.Vertical);
        }

        private void Update()
        {
            var moveDirection = new Vector2(_moveJoystick.Horizontal, _moveJoystick.Vertical);
            var lookDirection = new Vector2(_lookJoystick.Horizontal, _lookJoystick.Vertical);
            _player.Shoot(moveDirection, lookDirection);
        }
    }
}
