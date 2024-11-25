using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerVariables _playerVariables;

        private ref Vector2 MouseDirection => ref _playerVariables.mouseDirection;
        private ref Vector2 Movement => ref _playerVariables.movement;
        private Rigidbody2D Rb => _playerVariables.rb;
        private float Speed => _playerVariables.playerSpeed;

        private void Awake()
        {
            _playerVariables = GetComponent<PlayerVariables>();
        }

        void Update()
        {
            float alignment = Vector2.Dot(Movement.normalized, MouseDirection);
            Movement.x = alignment < 0 ? Movement.x * 0.5f : Movement.x;
        }

        void FixedUpdate()
        {
            Vector2 newPosition = Rb.position + Movement * (Speed * Time.fixedDeltaTime);
            Rb.MovePosition(newPosition);
        }
    }
}