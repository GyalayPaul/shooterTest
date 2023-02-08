using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shooter
{
    /// <summary>
    /// Utility class for audio features which are used in multiple locations.
    /// </summary>
    public static class AudioUtils
    {
        public static void PlayRandomizedOneshotSound(AudioSource audioSource, List<AudioClip> clips, float volume = 1, float pitchvariation = 0.05f)
        {
            if (clips.Count <= 0) return;
            var clip = clips[Random.Range(0, clips.Count)];
            audioSource.Stop();
            audioSource.volume = volume;
            audioSource.clip = clip;
            audioSource.loop = false;
            audioSource.pitch = 1 + Random.Range(-pitchvariation, pitchvariation);
            audioSource.Play();
        }
    }
}