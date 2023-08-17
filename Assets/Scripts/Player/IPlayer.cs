using UnityEngine;

namespace Game.Player
{
    public interface IPlayer
    {
        int Coins { get; }
        void Move(float horizontal, float vertical);
        void Shoot(Vector2 moveDirection, Vector2 lookDirection);
    }
}