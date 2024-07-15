using System;
using UnityEngine;
using TMPro;
using Zenject;
public abstract class ResourcesCounter : MonoBehaviour
{
    private int _resources;
    public int Resources { get => _resources; }

    [SerializeField]
    private TMP_Text _lable;

    [SerializeField]
    private AudioClip _audioClip;

    private SoundEffectsPlayer _soundEffectsPlayer;

    [Inject]
    public void Construct(SoundEffectsPlayer soundEffectsPlayer)
    {
        _soundEffectsPlayer = soundEffectsPlayer;
    }

    private void Awake()
    {
        _lable.text = _resources.ToString();
    }

    public void AddResource(int count)
    {
        if (count < 0) throw new ArgumentOutOfRangeException("count < 0");
        _resources += count;
        _lable.text = _resources.ToString();
        _soundEffectsPlayer.PlaySound(_audioClip);
    }

    public void ReduceResource(int count)
    {
        if (count < 0) throw new ArgumentOutOfRangeException("count < 0");
        if (_resources == 0) return;
        if (count > _resources)
        {
            _resources -= count;
        }
        else
        {
            _resources = 0;
        }
        _lable.text = _resources.ToString();
        _soundEffectsPlayer.PlaySound(_audioClip);
    }
}
