using System.IO;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

#endif

namespace Rich.Base.Runtime.Utility
{
    public class BundleUtility
    {
        public const string AssetBundlesOutputPath = "Assets/StreamingAssets";

        public const string AssetBundleExtension = ".unity3d";

        public static string GetAssetBundlePath(string name)
        {
            //var path = Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXEditor ? "file://" : "";
            var path = GetStreamingAssetsPath() + Path.DirectorySeparatorChar;
            path += GetPlatformName() + Path.DirectorySeparatorChar;
            //path += name.ToLower() + AssetBundleExtension;
            path += name.ToLower();
            return path;
        }
        
     

        /// <summary>
        /// Get streaming asset path according to platform
        /// </summary>
        public static string GetStreamingAssetsPath()
        {
            string path;
#if UNITY_EDITOR_WIN
            //path = "file:" + Application.dataPath + "/StreamingAssets";
            path = Application.streamingAssetsPath;
#elif UNITY_ANDROID
            path = Application.persistentDataPath;
#elif UNITY_EDITOR_OSX
            path = Application.streamingAssetsPath;
#elif UNITY_STANDALONE_OSX
			path = "file://" + Application.streamingAssetsPath;
#elif UNITY_IOS
			path = Application.persistentDataPath;
#elif UNITY_STANDALONE
            path = "file://" + Application.streamingAssetsPath;
#elif UNITY_WEBGL || UNITY_FACEBOOK
            path = Application.streamingAssetsPath;
#else
            //Desktop (Mac OS or Windows)
            path = "file:"+ Application.dataPath + "/StreamingAssets";
#endif

            return path;
        }

        /// <summary>
        /// Get platfrom name as string
        /// </summary>
        public static string GetPlatformName()
        {
#if UNITY_EDITOR
            return GetPlatformForAssetBundles(EditorUserBuildSettings.activeBuildTarget);
#else
			return GetPlatformForAssetBundles(Application.platform);
#endif
        }

#if UNITY_EDITOR
        /// <summary>
        /// Get platfrom name as string
        /// </summary>
        public static string GetPlatformForAssetBundles(BuildTarget target)
        {
            switch (target)
            {
                case BuildTarget.Android:
                    return "Android";
                case BuildTarget.iOS:
                    return "iOS";
                case BuildTarget.WebGL:
                    return "WebGL";
                case BuildTarget.StandaloneWindows:
                case BuildTarget.StandaloneWindows64:
                    return "Windows";
                case BuildTarget.StandaloneOSX:
                    return "OSX";
                //case BuildTarget.StandaloneLinux:
                case BuildTarget.StandaloneLinux64:
                    //case BuildTarget.StandaloneLinuxUniversal:
                    return "Linux";

                // AddTrooper more build targets for your own.
                // If you add more targets, don't forget to add the same platforms to GetPlatformForAssetBundles(RuntimePlatform) function.
                default:
                    return null;
            }
        }
#endif

        /// <summary>
        /// Get platfrom name as string
        /// </summary>
        public static string GetPlatformForAssetBundles(RuntimePlatform platform)
        {
            switch (platform)
            {
                case RuntimePlatform.Android:
                    return "Android";
                case RuntimePlatform.IPhonePlayer:
                    return "iOS";
                case RuntimePlatform.WebGLPlayer:
                    return "WebGL";
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                    return "Windows";
                case RuntimePlatform.OSXPlayer:
                    return "OSX";
                case RuntimePlatform.LinuxPlayer:
                case RuntimePlatform.LinuxEditor:
                    return "Linux";
                // AddTrooper more build targets for your own.
                // If you add more targets, don't forget to add the same platforms to GetPlatformForAssetBundles(RuntimePlatform) function.
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert path to string array
        /// </summary>
        public static string[] GetPathAsArray(string path)
        {
            return path.Split('/');
        }
    }
}