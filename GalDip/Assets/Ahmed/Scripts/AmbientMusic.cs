using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AmbientMusic : MonoBehaviour
{
    [SerializeField] private AudioClip[] ambientClips;
    [SerializeField] private float fadeInDuration = 2f;
    [SerializeField] private float fadeOutDelay = 40f;
    [SerializeField] private float fadeOutDuration = 2f;
    [SerializeField] private AudioMixerGroup mixerGroup;

    private AudioSource audioSource;
    private Coroutine currentRoutine;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (mixerGroup != null)
            audioSource.outputAudioMixerGroup = mixerGroup;
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
        audioSource.clip = clip;
        audioSource.volume = 0f;
        audioSource.Play();

        // Fade In
        float t = 0f;
        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, 1f, t / fadeInDuration);
            yield return null;
        }

        audioSource.volume = 1f;

        // Wait before fading out
        yield return new WaitForSeconds(fadeOutDelay);

        // Fade Out
        t = 0f;
        while (t < fadeOutDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(1f, 0f, t / fadeOutDuration);
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
    }
}