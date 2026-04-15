using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Player Movement
    private float _horizontalMovement;
    public float HorizontalMovement { get { return _horizontalMovement; } }

    private float _verticalMovement;
    public float VerticalMovement { get { return _verticalMovement; } }

    private bool _isSprinting;
    public bool IsSprinting { get { return _isSprinting; } }

    private bool _isJumping;
    public bool IsJumping { get { return _isJumping; } }
    #endregion

    private bool _isPausing;
    public bool IsPausing { get { return _isPausing; } }

    private bool _isInteracting;
    public bool IsInteracting { get { return _isInteracting; } }

    private void Update()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _verticalMovement = Input.GetAxisRaw("Vertical");
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
        _isJumping = Input.GetKeyDown(KeyCode.Space);

        _isPausing = Input.GetKeyDown(KeyCode.Escape);

        _isInteracting = Input.GetKeyDown(KeyCode.F);
    }
}
