using UnityEngine;

namespace Core
{
    [StaticUnload]
    [RequireComponent(typeof(AudioSource))]
    public class MusicSource : MonoBehaviour
    {
        private static MusicSource defaultMusicSource;

        private static MusicSource activeMusicSource;
        private AudioSource audioSource;
        public AudioSource AudioSource => audioSource;
        private float volumeMultiplier = 1.0f;

        public void Init()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.playOnAwake = false;

            volumeMultiplier = audioSource.volume;

            // audioSource.volume = AudioController.GetVolume(AudioType.Music) * volumeMultiplier;
            AudioController.VolumeChanged += OnVolumeChanged;
        }

        private void OnDestroy()
        {
            AudioController.VolumeChanged -= OnVolumeChanged;
        }

        public void Activate()
        {
            
        }

        private void OnVolumeChanged(AudioType audioType, float volume)
        {
            if (audioType != AudioType.Music) return;

            audioSource.volume = volume * volumeMultiplier;
        }

        private static void UnloadStatic()
        {
            defaultMusicSource = null;
            activeMusicSource = null;
        }
    }
}