using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private float _horizontalMovement;
    public float HorizontalMovement { get { return _horizontalMovement; } }

    private float _verticalMovement;
    public float VerticalMovement { get { return _verticalMovement; } }

    private bool _isSprinting;
    public bool IsSprinting { get { return _isSprinting; } }

    private bool _isJumping;
    public bool IsJumping { get { return _isJumping; } }

    private void Update()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _verticalMovement = Input.GetAxisRaw("Vertical");
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
        _isJumping = Input.GetKeyDown(KeyCode.Space);
    }

}
