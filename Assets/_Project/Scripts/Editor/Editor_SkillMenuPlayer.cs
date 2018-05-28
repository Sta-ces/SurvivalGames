using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SkillMenuPlayer))]
public class Editor_SkillMenuPlayer : Editor {

	public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SkillMenuPlayer scriptTarget = target as SkillMenuPlayer;

        // Call your custom function here
        // Exemple : scriptTarget.YourFunctionName();
        if (GUILayout.Button("Generate Skills"))
            scriptTarget.CreateSkills();
    }
}
