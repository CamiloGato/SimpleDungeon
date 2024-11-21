using UnityEngine;

namespace Player
{
    public class PlayerSword : MonoBehaviour
    {
        public float radius = 1.0f;
        public Transform swordTransform;

        private Transform _tf;
        private Camera _mainCamera;

        private void Awake()
        {
            _tf = GetComponent<Transform>();
        }

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        void Update()
        {
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector2 direction = mousePosition - _tf.position;
            direction.Normalize();

            Vector2 swordPosition = (Vector2) _tf.position + direction * radius;
            swordTransform.position = swordPosition;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            swordTransform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}