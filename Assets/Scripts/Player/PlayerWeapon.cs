using UnityEngine;

namespace Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        private PlayerVariables _playerVariables;

        private Camera _mainCamera;
        private SpriteRenderer _weaponSpriteRenderer;

        private Transform Tf => _playerVariables.tf;
        private Transform WeaponTransform => _playerVariables.weaponTransform;
        private float Radius => _playerVariables.weaponData ? _playerVariables.weaponData.weaponRange : 1.0f;
        private Sprite WeaponSprite => _playerVariables.weaponData?.itemImage;

        private void Awake()
        {
            _playerVariables = GetComponent<PlayerVariables>();
        }

        private void Start()
        {
            _mainCamera = Camera.main;
            _weaponSpriteRenderer = WeaponTransform.GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            _weaponSpriteRenderer.sprite = WeaponSprite ?? _weaponSpriteRenderer.sprite;

            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector2 direction = mousePosition - Tf.position;
            direction.Normalize();

            Vector2 weaponPosition = (Vector2) Tf.position + direction * Radius;
            WeaponTransform.position = weaponPosition;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            WeaponTransform.rotation = Quaternion.Euler(0f, 0f, angle);

            _weaponSpriteRenderer.flipY = angle is > 90 or < -90;
        }
    }
}