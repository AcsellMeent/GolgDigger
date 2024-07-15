using UnityEngine;
using Zenject;

public class UIJoyStickInstaller : MonoInstaller
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private RectTransform _joystickAxis;

    public override void InstallBindings()
    {
        var joystickInstance = Container.
        InstantiatePrefabForComponent<Joystick>
        (_joystick, _joystickAxis.position, Quaternion.identity, _joystickAxis);

        joystickInstance.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);

        Container.Bind<Joystick>().FromInstance(joystickInstance).AsSingle();
    }
}
