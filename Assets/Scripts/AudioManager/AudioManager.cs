using System;
using UnityEngine;

namespace AudioManager
{
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

        private AudioClip GETSoundClip(Sounds sound)
        {
            return Array.Find(Sounds, i => i.soundType == sound)?.soundClip;
        }
    }
}
