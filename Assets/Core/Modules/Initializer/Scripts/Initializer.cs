using UnityEngine;

namespace Core
{
    [DefaultExecutionOrder(-999)]
    public class Initializer : MonoBehaviour
    {
        private static Initializer initializer;
        [SerializeField] ProjectInitSettings initSettings;
        [SerializeField] SDKInitializer sdkInitializer;
        [SerializeField] SystemMessage systemMessage;
        [SerializeField] MusicSource globalMusicSource;
        public static GameObject GameObject { get; private set; }
        public static Transform Transform { get; private set; }
        public static ProjectInitSettings InitSettings { get; private set; }

        public void Init()
        {
            if (initializer != null) return;

            initializer = this;
            InitSettings = initSettings;
            GameObject = gameObject;
            Transform = transform;

#if MODULE_INPUT_SYSTEM

#else

#endif

            Overlay.Bind(new Overlay(gameObject));

            systemMessage.Init();
            DontDestroyOnLoad(gameObject);
        }

        public void InitModules()
        {
            
            initSettings.Init();

            if (globalMusicSource != null)
            {
                globalMusicSource.Init();
                globalMusicSource.Activate();
            }
        }

        public void InitSDKs()
        {
            sdkInitializer.Init();
        }
    }
    
}
