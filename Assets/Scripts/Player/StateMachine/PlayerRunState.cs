using UnityEngine;
using AnimationKeys = PlayerAnimationSwitcher.AnimationKeys;

public class PlayerRunState : PlayerMovementState
{
    public PlayerRunState(StateMachine stateMachine, PlayerComponentsProvider componentsProvider) : base(stateMachine, componentsProvider) { }

    public override void Enter()
    {
        AnimationSwitcher.SwitchAnimation(AnimationKeys.RUN);
    }

    public override void Update()
    {
        if (Joystick.Direction == Vector2.zero)
        {
            StateMachine.SwitchState<PlayerIdelState>();
            return;
        }

        // float radian = 45 * Mathf.Deg2Rad;
        // float cos = Mathf.Cos(radian);
        // float sin = Mathf.Sin(radian);

        // Vector3 rotatedVector = new Vector3(
        //     Vector3MoveDirection.x * cos - Vector3MoveDirection.z * sin,
        //     0,
        //     Vector3MoveDirection.x * sin + Vector3MoveDirection.z * cos
        // );

        float inputAngle = Mathf.Atan2(Joystick.Horizontal, Joystick.Vertical);

        inputAngle = inputAngle < 0 ? inputAngle + 2 * Mathf.PI : inputAngle;

        inputAngle -= Mathf.PI / 4;

        Vector3 direction = new Vector3(Mathf.Sin(inputAngle), 0, Mathf.Cos(inputAngle));

        Move(direction, MovementProperties.Speed);
    }
}
