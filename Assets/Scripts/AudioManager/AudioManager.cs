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
           PlayBGM();
        }

        public void PlayBGM(){
         var clip = GETSoundClip(global::AudioManager.Sounds.BackGroundMusic);
         if (clip != null)
            {
                soundMusic.clip = clip;
                soundMusic.Play();
            }
            else
            {
                Debug.LogError("BGM not found ");
            }

        }

/// <summary>
/// Plays requested sound either oneShot or continuous
/// <summary>
        public void Play(Sounds sound)
        {
            var clip = GETSoundClip(sound);
            if (clip != null)
            {
                   soundEffect.PlayOneShot(clip);
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
