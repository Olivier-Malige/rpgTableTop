
using UnityEngine;
using TMPro;
using System.Collections;

public class PlayMusic : MonoBehaviour
{
    public AudioSource audioSource;


    public void Play(AudioClip music, float fadeDuration)
    {
        StartCoroutine(PlayWithCrossfade(music, fadeDuration));
    }

    public void Stop(float fadeDuration)
    {
        StartCoroutine(StopWithCrossfade(fadeDuration));
    }

    private IEnumerator PlayWithCrossfade(AudioClip music, float fadeDuration)
    {
        // Create a new audio source for the new song
        AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
        newAudioSource.clip = music;
        newAudioSource.loop = true;
        newAudioSource.volume = 0f;
        newAudioSource.Play();

        // Fade out the current song
        float startVolume = audioSource.volume;
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / fadeDuration);
            yield return null;
        }
        audioSource.Stop();

        // Fade in the new song
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            newAudioSource.volume = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }

        // Remove the old audio source and update the current audio source
        Destroy(audioSource);
        audioSource = newAudioSource;
    }

    private IEnumerator StopWithCrossfade(float fadeDuration)
    {
        // Fade out the current song
        float startVolume = audioSource.volume;
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / fadeDuration);
            yield return null;
        }
        audioSource.Stop();

    }
}
