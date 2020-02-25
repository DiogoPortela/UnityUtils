using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Utils.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public AudioMixerGroup audioMixerGroup;
        public Sound[] allSounds;

        private void Awake()
        {
            foreach (Sound sound in allSounds)
            {
                GameObject soundSource = new GameObject($"{sound.name} Source");
                soundSource.transform.parent = this.transform;
                sound.source = soundSource.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.outputAudioMixerGroup = audioMixerGroup;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;
            }
        }

        public void Play(string soundName)
        {
            Sound currentSound = Array.Find(allSounds, sound => sound.name == soundName);
            if (currentSound == null)
                return;
            currentSound.source.Play();
        }
        public void Stop(string soundName)
        {
            Sound currentSound = Array.Find(allSounds, sound => sound.name == soundName);
            if (currentSound == null)
                return;
            currentSound.source.Stop();
        }
    }
}
