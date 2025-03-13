#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace EasyTextEffects
{
    public static class TimeUtil
    {
#if UNITY_EDITOR
        private static float _editorStartTime = -1;
#endif

        public static float GetTime(bool unscaled)
        {
            if (Application.isPlaying)
            {
                return unscaled ? Time.unscaledTime : Time.time;
            }
            else
            {
#if UNITY_EDITOR
                if (_editorStartTime < 0)
                {
                    _editorStartTime = (float)EditorApplication.timeSinceStartup; // Capture when this started
                }

                // Normalize time to start from 0 in the editor
                return (float)(EditorApplication.timeSinceStartup - _editorStartTime);
#else
            return 0f; // Fallback if outside editor
#endif
            }
        }
    }
}