using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private PlayerInputs controls;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        controls = new PlayerInputs();
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void FixedUpdate()
    {
        Vector2 moveInput = controls.Main.Movement.ReadValue<Vector2>();
        rigidBody.velocity = moveInput * _speed;
    }
}
