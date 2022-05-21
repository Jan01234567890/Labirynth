using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGeneration))]
public class EditorBotton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelGeneration LevelGeneration = (LevelGeneration)target;
        if(GUILayout.Button("Create Labirynth"))
        {
            LevelGeneration.GenerateLabirynth();
        }
    }
}
