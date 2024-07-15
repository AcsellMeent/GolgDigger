using UnityEngine;

public abstract class PlayerMovementState : PlayerState
{
    protected CharacterController CharacterController;
    protected Transform PlayerTransform;
    protected PlayerMovementProperties MovementProperties;
    protected Joystick Joystick;
    protected PlayerAnimationSwitcher AnimationSwitcher;
    protected PlayerCollisionProvider CollisionProvider;
    public PlayerMovementState(StateMachine stateMachine, PlayerComponentsProvider componentsProvider) : base(stateMachine, componentsProvider)
    {
        CharacterController = componentsProvider.CharacterController;
        PlayerTransform = componentsProvider.PlayerModel;
        MovementProperties = componentsProvider.MovementProperties;
        Joystick = componentsProvider.Joystick;
        AnimationSwitcher = componentsProvider.PlayerAnimationSwitcher;
        CollisionProvider = componentsProvider.PlayerCollisionProvider;
    }

    protected Vector3 Vector3MoveDirection => new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);

    protected void Move(Vector3 direction, float speed)
    {
        PlayerTransform.forward = new Vector3(direction.x, PlayerTransform.forward.y, direction.z);
        CharacterController.SimpleMove(direction * speed);
    }
}
