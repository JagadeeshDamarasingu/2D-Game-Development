using System;
using UnityEngine;

namespace AudioManager
{
/// <summary>
/// Single ton class for Managing sounds across the game
/// <summary>
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        public AudioSource soundEffect;
        public AudioSource soundMusic;
        public SoundType[] Sounds;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Play(global::AudioManager.Sounds.BackGroundMusic, false);
        }

/// <summary>
/// Plays requested sound either oneShot or continuous
/// <summary>
        public void Play(Sounds sound, Boolean oneShot)
        {
            var clip = GETSoundClip(sound);
            if (clip != null)
            {
                if(oneShot){
                soundEffect.PlayOneShot(clip);
                }else
                {
                    soundEffect.Play(clip);
                }
            }
            else
            {
                Debug.LogError("Clip not found : " + sound);
            }
        }

/// <summary>
/// finds the audio clip from array and returns it
/// if not found returns null
/// <summary>
        private AudioClip GETSoundClip(Sounds sound)
        {
            return Array.Find(Sounds, i => i.soundType == sound)?.soundClip;
        }
    }
}
