using UnityEngine;

public class EquipLampAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _player;

    private void Awake()
    {
        _player = GetComponent<PlayerController>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        _player.OnHandLampEquip += AnimationParamHandler;
    }

    private void AnimationParamHandler(bool isEquipped)
    {
        _animator.SetBool("isEquipped", isEquipped);
    }
}
