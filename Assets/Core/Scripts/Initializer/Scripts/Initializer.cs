using UnityEngine;

namespace Core
{
    [DefaultExecutionOrder(-999)]
    public class Initializer : MonoBehaviour
    {
        private static Initializer initializer;
        [SerializeField] ProjectInitSettings initSettings;
    }
    
}
