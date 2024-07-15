using UnityEngine;
using AnimationKeys = PlayerAnimationSwitcher.AnimationKeys;

public class PlayerActivityState : PlayerMovementState
{
    public PlayerActivityState(StateMachine stateMachine, PlayerComponentsProvider componentsProvider) : base(stateMachine, componentsProvider)
    {
        ActivitiesAnimations = ComponentsProvider.PlayerActivitiesAnimations;
    }

    protected PlayerActivitiesAnimations ActivitiesAnimations;
    protected Activity Activity;

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
        if (Activity && Activity.Active)
        {
            Activity.IncreaseProgress(Time.deltaTime);
        }
    }
    public override void Exit()
    {
        Activity.ActivityCompleted -= OnActivitiesCompleted;
        Activity.ActivityActiveChanged -= OnActivityActiveChanged;
        Activity = null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!Activity && other.GetComponent<Activity>())
        {
            Activity = other.GetComponent<Activity>();
            if (Activity.Active)
            {
                AnimationSwitcher.SwitchAnimation(ActivitiesAnimations.GetAnimationKeys(Activity));
            }
            Activity.ActivityCompleted += OnActivitiesCompleted;
            Activity.ActivityActiveChanged += OnActivityActiveChanged;
        }
        else
        {
            StateMachine.SwitchState<PlayerIdelState>();
        }
        CollisionProvider.TriggerStay -= OnTriggerStay;
    }

    private void OnActivitiesCompleted()
    {
        if (!Activity.Active)
        {
            AnimationSwitcher.SwitchAnimation(AnimationKeys.IDEL);
        }
    }

    private void OnActivityActiveChanged(bool active)
    {
        if (active) AnimationSwitcher.SwitchAnimation(ActivitiesAnimations.GetAnimationKeys(Activity));
    }

}
