using System.IO;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

namespace Core
{
    public static class RuntimeEditorUtils
    {        

         /// <summary>
        /// Get asset in project
        /// </summary>
        public static T GetAsset<T>() where T : ScriptableObject
        {
#if UNITY_EDITOR
            Type type = typeof(T);

            string[] assets = AssetDatabase.FindAssets("t:" + type.Name);
            if (assets.Length > 0)
            {
                return (T)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(assets[0]), type);
            }
#endif

            return null;
        }

        public static void SetDirty(Object obj)
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(obj);
#endif
        }
    }
}
