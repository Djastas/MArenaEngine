using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Corp_Kaktus.MArenaEngine.Scripts.EngineSettings.Editor
{
    /// <summary>
    /// Add data object in unity editor project settings.
    /// </summary>
    internal class EngineSettingsProvider : SettingsProvider
    {
        private SerializedObject _engineSettingsDataSerialized;
        private EngineSettingsProvider(string path, SettingsScope scope = SettingsScope.Project) : base(path, scope) {}
        
        
        public override void OnActivate(string searchContext, VisualElement rootElement)
            => _engineSettingsDataSerialized = new SerializedObject(EngineSettingsDataScriptable.LoadInstance());
        
        public override void OnGUI(string searchContext)
        {
            var dataProperty = _engineSettingsDataSerialized.FindProperty("data");
            EditorGUILayout.PropertyField(dataProperty, new GUIContent("Data"));
            _engineSettingsDataSerialized.ApplyModifiedPropertiesWithoutUndo();
            EngineSettingsDataScriptable.LoadData().Validate();
        }
        
        /// <summary>
        /// register with empty find keywords
        /// </summary>
        /// <returns></returns>
        [SettingsProvider]
        public static SettingsProvider Register() =>
            new EngineSettingsProvider("Project/MArenaEngine") 
                { keywords = new List<string>() };
    }
}