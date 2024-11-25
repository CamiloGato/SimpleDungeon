using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");

        private PlayerVariables _playerVariables;

        private Animator Animator => _playerVariables.animator;
        private SpriteRenderer SpriteRenderer => _playerVariables.spriteRenderer;
        private Vector2 Movement => _playerVariables.movement;
        private Vector2 MouseDirection => _playerVariables.mouseDirection;

        private void Awake()
        {
            _playerVariables = GetComponent<PlayerVariables>();
        }

        private void Update()
        {
            Animator.SetFloat(Horizontal, Movement.x);
            Animator.SetFloat(Vertical, Movement.y);

            SpriteRenderer.flipX = MouseDirection.x < 0;
        }
    }
}