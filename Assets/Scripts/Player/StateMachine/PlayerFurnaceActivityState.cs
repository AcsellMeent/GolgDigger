using UnityEngine;

public class PlayerFurnaceActivityState : PlayerActivityState
{
    public PlayerFurnaceActivityState(StateMachine stateMachine, PlayerComponentsProvider componentsProvider) : base(stateMachine, componentsProvider) { }

    public override void Update()
    {
        if (Joystick.Direction != Vector2.zero)
        {
            StateMachine.SwitchState<PlayerRunState>();
            return;
        }
    }
}
