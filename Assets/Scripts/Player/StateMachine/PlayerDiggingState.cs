using UnityEngine;
using AnimationKeys = PlayerAnimationSwitcher.AnimationKeys;

public class PlayerDiggingState : PlayerMovementState
{
    public PlayerDiggingState(StateMachine stateMachine, PlayerComponentsProvider componentsProvider) : base(stateMachine, componentsProvider) { }

    private DiggingActivities _diggingZone;

    public override void Enter()
    {
        CollisionProvider.TriggerStay += OnTriggerStay;
    }

    public override void Update()
    {
        if (Joystick.Direction != Vector2.zero)
        {
            StateMachine.SwitchState<PlayerRunState>();
            return;
        }

        _diggingZone?.IncreaseProgress(Time.deltaTime);
    }

    public override void Exit()
    {
        // _diggingZone.ActivityCompleted -= OnActivityCompleted;
        _diggingZone = null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_diggingZone && other.GetComponent<DiggingActivities>())
        {
            _diggingZone = other.GetComponent<DiggingActivities>();
            if (_diggingZone.Active)
            {
                AnimationSwitcher.SwitchAnimation(AnimationKeys.DIGGING);
            }
            CollisionProvider.TriggerStay -= OnTriggerStay;
            // _diggingZone.ActivityCompleted += OnActivityCompleted;
        }
    }

    private void OnActivityCompleted()
    {
        StateMachine.SwitchState<PlayerIdelState>();
    }
}
