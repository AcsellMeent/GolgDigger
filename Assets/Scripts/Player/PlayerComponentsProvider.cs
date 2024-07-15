using UnityEngine;
using Zenject;

public class PlayerComponentsProvider : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;

    public CharacterController CharacterController { get => _characterController; }

    [SerializeField]
    private Transform _playerModel;

    public Transform PlayerModel { get => _playerModel; }

    [SerializeField]
    private PlayerMovementProperties _movementProperties;

    public PlayerMovementProperties MovementProperties { get => _movementProperties; }

    private Joystick _joystick;
    public Joystick Joystick { get => _joystick; }

    [SerializeField]
    private PlayerAnimationSwitcher _playerAnimationSwitcher;
    public PlayerAnimationSwitcher PlayerAnimationSwitcher { get => _playerAnimationSwitcher; }

    [SerializeField]
    private PlayerCollisionProvider _playerCollisionProvider;
    public PlayerCollisionProvider PlayerCollisionProvider { get => _playerCollisionProvider; }

    
    [SerializeField]
    private PlayerActivitiesAnimations _playerActivitiesAnimations;
    public PlayerActivitiesAnimations PlayerActivitiesAnimations { get => _playerActivitiesAnimations; }


    [Inject]
    public void Construct(Joystick joystick)
    {
        _joystick = joystick;
    }
}
