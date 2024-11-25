using Items;
using UnityEngine;

namespace Player
{
    public class PlayerVariables : MonoBehaviour
    {
        [Header("Input Configuration")]
        public string inputHorizontal = "Horizontal";
        public string inputVertical = "Vertical";

        [Header("Player Configuration")]
        public float playerSpeed = 5.0f;
        public Inventory playerInventory;
        public WeaponData defaultWeapon;

        [Header("Weapon Configuration")]
        public Transform weaponTransform;

        [HideInInspector] public Vector2 movement;
        [HideInInspector] public Vector3 mousePosition;
        [HideInInspector] public Vector2 mouseDirection;

        [HideInInspector] public Rigidbody2D rb;
        [HideInInspector] public Transform tf;
        [HideInInspector] public Animator animator;
        [HideInInspector] public SpriteRenderer spriteRenderer;

        [HideInInspector] public WeaponData weaponData;
        [HideInInspector] public UtilityData utilityData;

        private Camera _mainCamera;

        private void Awake()
        {
            tf = transform;
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            // Update the MousePosition and MouseDirection
            mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            mouseDirection = (mousePosition - tf.position).normalized;

            // Update the Movement
            movement.x = Input.GetAxis(inputHorizontal);
            movement.y = Input.GetAxis(inputVertical);
        }
    }
}