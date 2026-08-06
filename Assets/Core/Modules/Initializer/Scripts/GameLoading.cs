using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    [StaticUnload]
    public class GameLoading : MonoBehaviour
    {
        private const float MINIMUM_LOADING_TIME = 2.0f;
        private static GameLoading gameLoading;
        [SerializeField] private Initializer initializer;
        [SerializeField] private LoadingGraphics loadingGraphics;
        
        [Space]
        [Tooltip("If manual mode is enabled, the loading screen will be active until GameLoading.MarkAsReadyToHide method has been called.")]
        [SerializeField] bool useManualControl;
        [SerializeField] bool checkNetworkConnection = true;
        private static AsyncOperation loadingOperation;
        private static bool isReadyToHide;
        public static string loadingMessage;
        private RemoteConfigHandler remoteConfigHandler;
        private static List<LoadingTask> loadingTasks = new List<LoadingTask>();
        private Coroutine initCoroutine;

        public static int LoadingSceneBuildIndex = -1;


        private void Awake()
        {
            gameLoading = this;
            DontDestroyOnLoad(gameObject);

            remoteConfigHandler = initializer.GetComponent<RemoteConfigHandler>();
            loadingGraphics.Init(this);

            initCoroutine = StartCoroutine(BootstrapCoroutine());
        } 

        private IEnumerator BootstrapCoroutine()
        {
            yield return null;
            yield return new WaitForEndOfFrame();

            initializer.Init();

            yield return ConnectionCheckCoroutine();
        }

        private IEnumerator ConnectionCheckCoroutine()
        {
            loadingGraphics.HideErrorMessage();
            loadingGraphics.SetLoadingState(0, "Checking connection...");

            if(checkNetworkConnection)
            {
                bool isConnected = false;

                NetworkConnection networkConnection = new NetworkConnection("https://google.com/");
                IEnumerator connectionCheck = networkConnection.CheckConnection((state) => isConnected = state);

                yield return connectionCheck;

                if (!isConnected)
                {
                    loadingGraphics.ShowErrorMessage("Connection error");

                    initCoroutine = null;

                    yield break;
                }
            }

            if(remoteConfigHandler != null)
            {
                bool isConfigLoaded = false;

                loadingGraphics.SetLoadingState(0.1f, "Loading Data..");

                IEnumerator configLoad = remoteConfigHandler.LoadConfig((state) => isConfigLoaded = state);

                yield return configLoad; 
                
                if (!isConfigLoaded)
                {
                    loadingGraphics.ShowErrorMessage("Failed to load data");

                    initCoroutine = null;

                    yield break;
                }
            }
            else
            {
                loadingGraphics.SetLoadingState(0.1f, "Loading..");
            }

            initializer.InitModules();
            initializer.InitSDKs();

            int taskIndex = 0;
            while (taskIndex < loadingTasks.Count)
            {
                if (!loadingTasks[taskIndex].IsActive)
                    loadingTasks[taskIndex].Activate();

                if (loadingTasks[taskIndex].IsFinished)
                {
                    taskIndex++;
                }

                yield return null;
            }

            yield return null;
            yield return null;
            yield return null;

            float realtimeSinceStartup = Time.realtimeSinceStartup;

            int sceneIndex = LoadingSceneBuildIndex;
            if(sceneIndex == -1)
            {
                sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (SceneManager.sceneCount < sceneIndex)
                    Debug.LogError("[Loading]: First scene is missing!");
            }

            float minimumFinishTime = realtimeSinceStartup + MINIMUM_LOADING_TIME;

            loadingOperation = SceneManager.LoadSceneAsync(sceneIndex);

            loadingMessage = "Loading..";

            while (!loadingOperation.isDone || realtimeSinceStartup < minimumFinishTime)
            {
                yield return null;

                realtimeSinceStartup = Time.realtimeSinceStartup;

                loadingGraphics.SetLoadingState(Mathf.Lerp(0.2f, 0.9f, loadingOperation.progress), loadingMessage);
            }

            loadingGraphics.SetLoadingState(1.0f, "Completed");

            loadingGraphics.OnLoadingFinished();

            Destroy(gameObject);

        }

        public void RetryConnection()
        {
            if(initCoroutine == null)
            {
                initCoroutine = StartCoroutine(ConnectionCheckCoroutine());
            }
        }

        private static void UnloadStatic()
        {
            isReadyToHide = false;
            loadingTasks.Clear();
        }
    }

}
