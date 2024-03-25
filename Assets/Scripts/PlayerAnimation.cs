using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public PlayerMove _playerMove;

    public void AnimationOn()
    {
        if (_playerMove.movement.z >= 1)
        {
            _animator.SetBool("WalcingForward", true);
        }

        if (_playerMove.movement.z <= -1)
        {
            _animator.SetBool("WalcingBack", true);
        }

        if (_playerMove.movement.x <= -0.8 && (_playerMove.movement.z <= 0.8))
        {
            _animator.SetBool("LeftForwardDiadonaleStrafeWalking", true);
        }
    }

    public void AnimationOff()
    {
        if (_playerMove.movement.magnitude == 0)
        {
            _animator.SetBool("WalcingForward", false);
            _animator.SetBool("WalcingBack", false);
            _animator.SetBool("LeftForwardDiadonaleStrafeWalking", false);
        }
    }
}
