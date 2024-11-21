using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5f;
        private Rigidbody2D _rb;
        private Vector2 _movement;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private Camera _mainCamera;
        private Transform _tf;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _tf = transform;
        }

        void Start()
        {
            _mainCamera = Camera.main;
        }

        void Update()
        {
            _movement.x = Input.GetAxis("Horizontal");
            _movement.y = Input.GetAxis("Vertical");

            _animator.SetFloat("Horizontal", _movement.x);
            _animator.SetFloat("Vertical", _movement.y);

            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector2 directionToMouse = (mousePosition - _tf.position).normalized;

            _spriteRenderer.flipX = directionToMouse.x < 0;

            float alignment = Vector2.Dot(_movement.normalized, directionToMouse);
            _movement.x = alignment < 0 ? _movement.x * 0.5f : _movement.x;
        }

        void FixedUpdate()
        {
            Vector2 newPosition = _rb.position + _movement * (speed * Time.fixedDeltaTime);
            _rb.MovePosition(newPosition);
        }
    }
}