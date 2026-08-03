using UnityEngine;

namespace Core
{
    [CreateAssetMenu]
    public class ProjectInitSettings : ScriptableObject
    {
        [SerializeField] InitModule[] modules;
        public InitModule[] Modules => modules;

        public void Init()
        {
            for (int i = 0; i < modules.Length; i++)
            {
                if (modules[i] != null)
                {
                    modules[i].CreateComponent();
                }
            }
        }

        public T GetModule<T>() where T : InitModule
        {
            foreach(InitModule module in modules)
            {
                if (module != null && module is T)
                {
                    return (T)module;
                }
            }

            return null;
        }
    }
}