using UnityEngine;

namespace Core
{
    public abstract class SDKBehavior : MonoBehaviour
    {
        public virtual void Init() { }

        public abstract void OnUserConsentReceived();
    }
}
