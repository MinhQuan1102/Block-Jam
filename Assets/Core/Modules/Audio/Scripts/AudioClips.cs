using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "Audio Clips", menuName = "Data/Core/Audio Clips")]
    public class AudioClips : ScriptableObject
    {
        // [BoxGroup("UI", "UI")]
        public AudioClip buttonSound;

        // [BoxGroup("Gameplay", "Gameplay")]
        public AudioClip blockPick;
        
        // [BoxGroup("Gameplay")]
        public AudioClip blockDestroy;

        // [BoxGroup("Gameplay")]
        public AudioClip win;
        
        // [BoxGroup("Gameplay")]
        public AudioClip lose;

        // [BoxGroup("Gameplay")]
        public AudioClip revive;

        // [BoxGroup("Gameplay")]
        public AudioClip actionDone;
    }
}