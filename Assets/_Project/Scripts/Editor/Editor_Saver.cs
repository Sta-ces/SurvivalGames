using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Saver))]
public class Editor_Saver : Editor {

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Reset PlayerPrefs"))
            PlayerPrefs.DeleteAll();

        if (GUILayout.Button("Reset HighScore"))
        	PlayerPrefs.DeleteKey("HighScore");
    }
}
