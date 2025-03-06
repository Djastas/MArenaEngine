using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Corp_Kaktus.MArenaEngine.Scripts.EngineSettings.Editor
{
    public class EngineSettingsController : SettingsProvider
    {
        private SerializedObject _engineSettingsDataSerialized;
        
        public EngineSettingsController(string path, SettingsScope scope = SettingsScope.Project) 
            : base(path, scope) {}
        
        public override void OnActivate(string searchContext, VisualElement rootElement)
            => _engineSettingsDataSerialized = new SerializedObject(EngineSettingsDataScriptable.LoadData());

        public override void OnGUI(string searchContext)
        {
            var iterator = _engineSettingsDataSerialized.FindProperty("data");
            EditorGUILayout.PropertyField(iterator, new GUIContent("Data"));
            _engineSettingsDataSerialized.ApplyModifiedPropertiesWithoutUndo();
            EngineSettingsDataScriptable.LoadData().data.Validate();
        }
        
        [SettingsProvider]
        public static SettingsProvider Register() =>
            new EngineSettingsController("Project/MArenaEngine") 
                { keywords = new List<string>() };
    }
}