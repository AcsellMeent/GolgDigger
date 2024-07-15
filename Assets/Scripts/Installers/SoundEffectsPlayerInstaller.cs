using UnityEngine;
using Zenject;

public class SoundEffectsPlayerInstaller : MonoInstaller
{
    [SerializeField]
    private SoundEffectsPlayer _soundEffectsPlayer;

    public override void InstallBindings()
    {
        var soundEffectsPlayer = Container.InstantiatePrefabForComponent<SoundEffectsPlayer>(_soundEffectsPlayer);

        Container.Bind<SoundEffectsPlayer>().FromInstance(soundEffectsPlayer).AsSingle();
    }
}
