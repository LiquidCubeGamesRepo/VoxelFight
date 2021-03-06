﻿using System.Collections.Generic;
using UnityEngine;

namespace Audio { 

    /// <summary>
    /// Audio liblary
    /// </summary>
    [CreateAssetMenu (menuName = "SoundMenager")]
    public class SoundMenager : ScriptableObject {

        [SerializeField] List<AudioClip> hitClips;
        [SerializeField] List<AudioClip> shootClips;
        [SerializeField] AudioClip menuMusic;
        [SerializeField] AudioClip gameMusic;

        public AudioClip GetHitClip()
        {
            int n = Random.Range (0, hitClips.Count - 1);
            return hitClips[n];
        }

        public AudioClip GetMachineWeaponClip()
        {
            return shootClips[0];
        }
        public AudioClip GetLaserWeaponClip()
        {
            return shootClips[1];
        }
        public AudioClip GetRocketSoundClip()
        {
            return shootClips[2];
        }
        public AudioClip GetShotgunSoundClip()
        {
            return shootClips[3];
        }

        public AudioClip GetMenuClip()
        {
            return menuMusic;
        }

        public AudioClip GetGameClip()
        {
            return gameMusic;
        }

    }
}