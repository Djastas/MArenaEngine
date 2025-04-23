using System;
using System.Linq;
using Corp_Kaktus.MArenaEngine.Scripts.EngineSettings;
using Unity.Multiplayer;
using Unity.Multiplayer.Editor;
using UnityEditor;
using UnityEditor.Build.Profile;

using UnityEngine;
// ReSharper disable InconsistentNaming

namespace Build
{
    public static class BuildActions
    {
        private const string VR_Android_BuildProfilePath = "Assets/Settings/Build Profiles/VR_Android.asset";
        private const string VR_PC_BuildProfilePath = "Assets/Settings/Build Profiles/VR_PC.asset";

        private const string Console_Android_BuildProfilePath = "Assets/Settings/Build Profiles/VR_PC.asset";
        private const string Console_Window_BuildProfilePath = "Assets/Settings/Build Profiles/VR_PC.asset";
        
        private const string Server_DedicatedWindow_BuildProfilePath = "Assets/Settings/Build Profiles/Server_PC.asset";
        
        
        
        private const string VR_Android_BuildPath = @"Builds\VR\MarenaEngine.apk";
        private const string VR_PC_BuildPath = @"Builds\VR_PC\MarenaEngine_Simulator.exe";

        private const string Console_Android_BuildPath = @"Builds\ConsoleAndroid\MarenaEngine_Console.apk";
        private const string Console_Window_BuildPath = @"Builds\ConsolePC\MarenaEngine_Console.exe";
        
        private const string Server_DedicatedWindow_BuildPath = @"Builds\ServerPC\MarenaEngine_Server.exe";
        
        
        
        /*public static void AndroidDevelopment () {
            /*PlayerSettings.SetScriptingBackend (BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
            PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.Android, "DEV");
            EditorUserBuildSettings.SwitchActiveBuildTarget (BuildTargetGroup.Android, BuildTarget.Android);
            EditorUserBuildSettings.development = true;
            EditorUserBuildSettings.androidETC2Fallback = AndroidETC2Fallback.Quality32Bit;#1#
            var buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.locationPathName =  "Builds/VR_PC";
            
            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            int code = (report.summary.result == BuildResult.Succeeded) ? 0 : 1;
            EditorApplication.Exit (code);   
        }*/

        public static void VR_PC_Build()
        {
            // setup ----------------

            EngineSettings.settings.useVRSimulator = true;
            EngineSettings.settings.controlClientBuild = false;
            
            EditorMultiplayerRolesManager.ActiveMultiplayerRoleMask  = MultiplayerRoleFlags.Client;
            // Build ----------------
            var buildProfile = LoadBuildProfile(VR_PC_BuildProfilePath);
            BuildProfile.SetActiveBuildProfile(buildProfile);
            BuildPipeline.BuildPlayer(buildProfile.scenes, VR_PC_BuildPath,
                BuildTarget.StandaloneWindows64, BuildOptions.None);
        }
        
        public static void VR_Android_Build()
        {
            // setup ----------------

            EngineSettings.settings.useVRSimulator = false;
            EngineSettings.settings.controlClientBuild = false;
            
            EditorMultiplayerRolesManager.ActiveMultiplayerRoleMask  = MultiplayerRoleFlags.Client;
            
            // Build ----------------
            var buildProfile = LoadBuildProfile(VR_Android_BuildProfilePath);
            BuildProfile.SetActiveBuildProfile(buildProfile);
            BuildPipeline.BuildPlayer(buildProfile.scenes, VR_Android_BuildPath,
                BuildTarget.Android, BuildOptions.None);
        }
        public static void Server_DedicatedWindow_Build()
        {
            // setup ----------------
            
            EngineSettings.settings.useVRSimulator = false;
            EngineSettings.settings.controlClientBuild = false;
            
            
            EditorMultiplayerRolesManager.ActiveMultiplayerRoleMask  = MultiplayerRoleFlags.Server;
            
            // Build ----------------
            
            var buildProfile = LoadBuildProfile(Server_DedicatedWindow_BuildProfilePath);
            BuildProfile.SetActiveBuildProfile(buildProfile);
            BuildPipeline.BuildPlayer(buildProfile.scenes, Server_DedicatedWindow_BuildPath,
                BuildTarget.StandaloneWindows64, BuildOptions.None);
        }
        

        private static BuildProfile LoadBuildProfile(string path)
        {
            var buildProfile = AssetDatabase.LoadAssetAtPath<BuildProfile>(path);
            
            if (buildProfile != null)
            {
               return buildProfile;
            }

            Debug.LogError("Build profile not found at: " + path);
            throw new Exception("Build profile not found at: " + path);
        }

        static string[] GetScenePaths()
        {
            return EditorBuildSettings.scenes
                .Where(scene => scene.enabled)
                .Select(scene => scene.path)
                .ToArray();
        }
    }
}