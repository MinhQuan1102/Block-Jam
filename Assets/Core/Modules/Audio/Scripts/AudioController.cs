using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [StaticUnload]
    public class AudioController
    {
        private static List<AudioSourceCase> audioSourcesPool;

        private static AudioClips audioClips;
        public static AudioClips AudioClips => audioClips;

        private static AudioListener audioListener;
        public static AudioListener AudioListener => audioListener;

        private static AudioSave save;

        // Default 3D audio settings
        private static float maxDistance = 30;
        private static float spread = 180;
        private static AnimationCurve rolloffCurve = new AnimationCurve(new Keyframe(0.0f, 1.0f), new Keyframe(1.0f, 0.0f));

        public static OnVolumeChangedCallback VolumeChanged;

        private static Dictionary<AudioType, float> volumeDictionary;

        public static void Init(AudioClips audioClips, int audioSourcesPoolSize)
        {
            if (audioClips == null)
            {
                Debug.LogError("[AudioController]: Audio Clips is NULL! Please assign audio clips scriptable on Audio Controller script.");

                return;
            }

            // TODO: Save Controller
            volumeDictionary = new Dictionary<AudioType, float>();

            CreateAudioListener();

            AudioController.audioClips = audioClips;

            audioSourcesPool = new List<AudioSourceCase>();
            for (int i = 0; i < audioSourcesPoolSize; i++)
            {
                audioSourcesPool.Add(new AudioSourceCase());
            }

        }

        private static void CreateAudioListener()
        {
            if (audioListener != null)
                return;

            // Create game object for listener
            GameObject listenerObject = new GameObject("[AUDIO LISTENER]");
            listenerObject.transform.position = Vector3.zero;

            // Mark as non-destroyable
            GameObject.DontDestroyOnLoad(listenerObject);

            // Add listener component to created object
            audioListener = listenerObject.AddComponent<AudioListener>();
        }

        public static void SetVolume(AudioType audioType, float volume)
        {
            foreach (AudioSourceCase audioSource in audioSourcesPool)
            {
                audioSource.OverrideVolume(audioType, volume);
            }

            volumeDictionary[audioType] = volume;
            // TODO: Save Controller
            // SaveController.MarkAsSaveIsRequired();

            VolumeChanged?.Invoke(audioType, volume);
        }

        public static float GetVolume(AudioType audioType)
        {
            if (volumeDictionary.ContainsKey(audioType))
                return volumeDictionary[audioType];

            return 1.0f;
        }

        public static void ApplyDefaultSettings(ref AudioSource audioSource)
        {
            
        }


    }
    public delegate void OnVolumeChangedCallback(AudioType audioType, float volume);

    public enum AudioType
    {
        Music = 0,
        Sound = 1
    }
}