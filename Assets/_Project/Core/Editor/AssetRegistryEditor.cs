#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Reflection;
using Wordania.Core.Data;

namespace Wordania.Core.Editor
{
    [CustomEditor(typeof(AssetRegistry<>), true)]
    public class AssetCatalogEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(15);

            GUI.backgroundColor = new Color(0.3f, 0.8f, 0.3f); // Slight green tint
            if (GUILayout.Button("Auto-Find All Assets", GUILayout.Height(30)))
            {
                MethodInfo method = target.GetType().GetMethod("Editor_FindAllAssets");
                if (method != null)
                {
                    method.Invoke(target, null);
                }
                else
                {
                    Debug.LogError("Could not find method Editor_FindAllAssets via reflection.");
                }
            }
            GUI.backgroundColor = Color.white;
        }
    }
}
#endif