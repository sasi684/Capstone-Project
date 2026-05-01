using UnityEngine;

public class PlayerInput : GenericSingleton<PlayerInput>
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
    #region Player Interactions
    private bool _isPausing;
    public bool IsPausing { get { return _isPausing; } }

    private bool _isInteracting;
    public bool IsInteracting { get { return _isInteracting; } }

    private bool _isEquippingLamp;
    public bool IsEquippingLamp { get { return _isEquippingLamp; } }
    #endregion

    private bool _inputsEnabled = true;

    private void Update()
    {
        if (_inputsEnabled)
        {
            _horizontalMovement = Input.GetAxisRaw("Horizontal");
            _verticalMovement = Input.GetAxisRaw("Vertical");
            _isSprinting = Input.GetKey(KeyCode.LeftShift);
            _isJumping = Input.GetKeyDown(KeyCode.Space);

            _isPausing = Input.GetKeyDown(KeyCode.Escape);

            _isInteracting = Input.GetMouseButtonDown(0);

            _isEquippingLamp = Input.GetKeyDown(KeyCode.F);
        }
    }

    public void DisablePlayerInput()
    {
        _inputsEnabled = false;
    }

    public void EnablePlayerInput()
    {
        _inputsEnabled = true;
    }
}
