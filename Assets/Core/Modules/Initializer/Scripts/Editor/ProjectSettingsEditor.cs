using UnityEditor;
using UnityEngine;

namespace Core
{
    [CustomEditor(typeof(ProjectInitSettings))]
    public class ProjectInitSettingsEditor : Editor
    {
        [MenuItem("Window/Core/Project Init Settings", priority = 50)]
        public static void SelectProjectInitSettings()
        {
            ProjectInitSettings selectedObject = EditorUtils.GetAsset<ProjectInitSettings>();
            if (selectedObject != null)
            {
                Selection.activeObject = selectedObject;
            }
            else
            {
                Debug.LogError("Asset with type \"ProjectInitSettings\" don`t exist.");
            }
        }
    }
}