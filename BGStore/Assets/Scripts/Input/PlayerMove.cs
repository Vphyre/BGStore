using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private PlayerInputs controls;
    private Rigidbody2D rigidBody;
    public UnityEvent OnMoveUp;
    public UnityEvent OnMoveDown;
    public UnityEvent OnMoveLeft;
    public UnityEvent OnMoveRight;
    public UnityEvent OnStop;

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

        if (moveInput.y > 0)
        {
            OnMoveUp?.Invoke();
        }
        else if (moveInput.y < 0)
        {
            OnMoveDown?.Invoke();
        }

        if (moveInput.x > 0)
        {
            OnMoveRight?.Invoke();
        }
        else if (moveInput.x < 0)
        {
            OnMoveLeft?.Invoke();
        }
        
        if (moveInput.x == 0 && moveInput.y == 0)
        {
            OnStop?.Invoke();
        }
    }
}
