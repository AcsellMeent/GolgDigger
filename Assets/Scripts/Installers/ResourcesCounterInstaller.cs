using UnityEngine;
using Zenject;

public class ResourcesCounterInstaller : MonoInstaller
{
    [SerializeField]
    private CoinCounter _coinCounter;

    [SerializeField]
    private GoldCounter _goldCounter;

    [SerializeField]
    private RectTransform _CountersAxis;

    public override void InstallBindings()
    {
        var coinsCounter = Container.InstantiatePrefabForComponent<CoinCounter>(_coinCounter, _CountersAxis);
        var goldCounter = Container.InstantiatePrefabForComponent<GoldCounter>(_goldCounter, _CountersAxis);

        Container.Bind<CoinCounter>().FromInstance(coinsCounter).AsSingle();
        Container.Bind<GoldCounter>().FromInstance(goldCounter).AsSingle();
    }
}
