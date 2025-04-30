using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    
    [SerializeField] private float fadeInDuration = 2f;
    [SerializeField] private float fadeOutDelay = 40f;
    [SerializeField] private float fadeOutDuration = 2f;
   
    
    [Header("Mixer Groups")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup voiceMixerGroup;
    [SerializeField] private AudioMixerGroup sFXMixerGroup;
    
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource voiceSource;
    [SerializeField] private AudioSource sFXSource;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] ambientClips;
    [SerializeField] private AudioClip[] whisperClips;
    [SerializeField] private AudioClip[] sfxClips;
    
    private Coroutine currentRoutine;

    void Start()
    {
        musicSource.outputAudioMixerGroup = musicMixerGroup;
        voiceSource.outputAudioMixerGroup = voiceMixerGroup; 
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        sFXSource.clip = clip;
        sFXSource.Play();
    }
    public void PlayVoiceOver(AudioClip clip)
    {
        voiceSource.clip = clip;
        voiceSource.Play();
    }

    public void PlayTrackWithFade(int index)
    {
        if (index < 0 || index >= ambientClips.Length) return;

        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(FadeInAndOutRoutine(ambientClips[index]));
    }

    IEnumerator FadeInAndOutRoutine(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.volume = 0f;
        musicSource.Play();

        // Fade In
        float t = 0f;
        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(0f, 1f, t / fadeInDuration);
            yield return null;
        }

        musicSource.volume = 1f;

        // Wait before fading out
        yield return new WaitForSeconds(fadeOutDelay);

        // Fade Out
        t = 0f;
        while (t < fadeOutDuration)
        {
            t += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(1f, 0f, t / fadeOutDuration);
            yield return null;
        }

        musicSource.volume = 0f;
        musicSource.Stop();
    }
}