using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectsPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    private Queue<AudioSource> _audioSourcePool;
    private List<AudioSource> activeLoopingSources;

    [SerializeField]
    private int _poolSize;

    private void Awake()
    {
        InitializeAudioSourcePool();
        activeLoopingSources = new List<AudioSource>();
    }
    public void PlaySoundEffect(AudioClip clip, float volume = 1.0f)
    {
        // _audioSource.PlayOneShot(clip, volume);
    }

    private void InitializeAudioSourcePool()
    {
        _audioSourcePool = new Queue<AudioSource>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = new GameObject("AudioSource_" + i);
            AudioSource audioSource = obj.AddComponent<AudioSource>();
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            _audioSourcePool.Enqueue(audioSource);
        }
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f, bool loop = false)
    {
        if (_audioSourcePool.Count > 0)
        {
            AudioSource source = _audioSourcePool.Dequeue();
            source.clip = clip;
            source.volume = volume;
            source.loop = loop;
            source.gameObject.SetActive(true);
            source.Play();
            if (loop) activeLoopingSources.Add(source);
            StartCoroutine(ReturnToPoolAfterPlay(source, clip.length));
        }
    }

    private IEnumerator ReturnToPoolAfterPlay(AudioSource source, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!source.loop)
        {
            source.Stop();
            source.clip = null;
            source.gameObject.SetActive(false);
            _audioSourcePool.Enqueue(source);
        }
    }

    public void StopLoopingSound(AudioClip clip)
    {
        AudioSource source = activeLoopingSources.Find(s => s.clip == clip);
        if (source != null)
        {
            source.Stop();
            source.clip = null;
            source.gameObject.SetActive(false);
            activeLoopingSources.Remove(source);
            _audioSourcePool.Enqueue(source);
        }
        else
        {
            Debug.LogWarning("AudioManager: No active looping sound found for the provided AudioClip.");
        }
    }
}
