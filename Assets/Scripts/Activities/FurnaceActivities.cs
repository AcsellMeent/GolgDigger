using UnityEngine;
using Zenject;

public class FurnaceActivities : LimitedActivity
{
    private SoundEffectsPlayer _soundEffectsPlayer;

    [SerializeField]
    private AudioClip _audioClip;

    private CoinCounter _coinCounter;
    private GoldCounter _goldCounter;

    private bool _canPlay;

    [Inject]
    public void Construct(CoinCounter coinCounter, GoldCounter goldCounter, SoundEffectsPlayer soundEffectsPlayer)
    {
        _coinCounter = coinCounter;
        _goldCounter = goldCounter;
        _soundEffectsPlayer = soundEffectsPlayer;
        _canPlay = true;
    }

    public override void IncreaseProgress(float value)
    {
        base.IncreaseProgress(value);
        if (_canPlay)
        {
            _canPlay = false;
            _soundEffectsPlayer.PlaySound(_audioClip, volume: 0.1f, loop: true);
        }
    }

    protected override void OnActiveChanged(bool active)
    {
        base.OnActiveChanged(active);
        if (!active)
        {
            _soundEffectsPlayer.StopLoopingSound(_audioClip);
        }
    }

    protected override void OnProgressCompleted()
    {
        base.OnProgressCompleted();
        _coinCounter.AddResource(1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerComponentsProvider>())
        {
            int requiredQuantity = MaxResources - CurrentResources;
            int quantity = _goldCounter.Resources < requiredQuantity ? _goldCounter.Resources : requiredQuantity;
            _goldCounter.ReduceResource(quantity);
            AddResources(quantity);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<PlayerComponentsProvider>())
        {
            _soundEffectsPlayer.StopLoopingSound(_audioClip);
            _canPlay = true;
        }
    }
}
