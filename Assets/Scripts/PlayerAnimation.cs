using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public PlayerMovement playerMovement;

  
    private void FixedUpdate()
    {
        AnimationOn();
        AnimationOff();
    }

    public void AnimationOn()
    {
        if (playerMovement.movement.z == 1)
        {
            _animator.SetBool("WalcingForward", true);
        }

        if (playerMovement.movement.z == -1)
        {
            _animator.SetBool("WalcingBack", true);
        }

        if (playerMovement.movement.x == 1)
        {
            _animator.SetBool("RightWalcing", true);
        }

        if (playerMovement.movement.x == -1)
        {
            _animator.SetBool("LeftWalcing", true);
        }
    }

    public void AnimationOff()
    {
        if (playerMovement.movement.magnitude == 0 )
        {
            _animator.SetBool("WalcingForward", false);
            _animator.SetBool("WalcingBack", false);
            _animator.SetBool("LeftWalcing", false);
            _animator.SetBool("RightWalcing", false);
        }
    }
}
