using UnityEngine;
using AnimationKeys = PlayerAnimationSwitcher.AnimationKeys;

public class PlayerIdelState : PlayerMovementState
{
    public PlayerIdelState(StateMachine stateMachine, PlayerComponentsProvider componentsProvider) : base(stateMachine, componentsProvider) { }

    public override void Enter()
    {
        CollisionProvider.TriggerStay += OnTriggerStay;
        AnimationSwitcher.SwitchAnimation(AnimationKeys.IDEL);
    }


    public override void Update()
    {
        if (Joystick.Direction != Vector2.zero)
        {
            StateMachine.SwitchState<PlayerRunState>();
            return;
        }
    }

    public override void Exit()
    {
        CollisionProvider.TriggerStay -= OnTriggerStay;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Activity>())
        {
            StateMachine.SwitchState<PlayerActivityState>();
        }
    }
}
