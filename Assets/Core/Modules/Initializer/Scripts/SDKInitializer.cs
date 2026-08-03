using UnityEngine;

namespace Core
{
    public class SDKInitializer : MonoBehaviour
    {
        private SDKBehavior[] behaviors;
        private ISDKTaskBehavior[] tasksBehaviors;
        private bool isCompleted;

        public void Init()
        {
            isCompleted = false;

            behaviors = GetComponents<SDKBehavior>();
            foreach(SDKBehavior behavior in behaviors)
            {
                behavior.Init();
            }

            tasksBehaviors = GetComponents<ISDKTaskBehavior>();
            foreach(ISDKTaskBehavior taskBehavior in tasksBehaviors)
            {
                taskBehavior.Init(this);
                
            }
        }
    }
    
}
