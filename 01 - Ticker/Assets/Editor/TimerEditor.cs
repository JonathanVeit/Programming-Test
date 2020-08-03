using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Timer))]
[CanEditMultipleObjects]
public class TimerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var t = (target as Timer);

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Start"))
        {
            t.StartTicker(t.frequence);
        }

        if (GUILayout.Button("Stop"))
        {
            t.StopTicker();
        }

        EditorGUILayout.EndHorizontal();
    }
}
