using UnityEngine;
using Zenject;

public class PlayerInstallser : MonoInstaller
{
    [SerializeField] private PlayerComponentsProvider _player;
    [SerializeField] private Transform _playerSpawnPoint;

    public override void InstallBindings()
    {
        var playerInstance = Container.InstantiatePrefabForComponent<PlayerComponentsProvider>(_player, _playerSpawnPoint.position, Quaternion.identity, null);

        Container.Bind<PlayerComponentsProvider>().FromInstance(playerInstance).AsSingle();
    }
}
