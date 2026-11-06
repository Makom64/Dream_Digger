using UnityEngine;
using UnityEngine.InputSystem;

public class TempMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _tempAction;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveSpeed;
    
    private void Awake()
    {
        CacheComponents();
    }
    
    private void OnEnable()
    {
        _tempAction.action.Enable();
        _tempAction.action.performed += OnMove;
        // _tempAction.action.canceled += OnStopMove;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = _moveSpeed;
    }

    private void OnDisable()
    {
        _tempAction.action.performed -= OnMove;
        // _tempAction.action.canceled -= OnStopMove;
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        // 좌우로 벡터값만큼
        _moveSpeed =  ctx.ReadValue<Vector2>();
        Debug.Log("Performed");
    }

    private void OnStopMove(InputAction.CallbackContext ctx)
    {
        //_rigidbody2D.linearVelocity =  Vector2.zero;
    }

    private void CacheComponents()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
