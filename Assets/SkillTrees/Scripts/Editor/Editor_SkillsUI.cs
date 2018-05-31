using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SkillsUI))]
public class Editor_SkillsUI : Editor {

	public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SkillsUI scriptTarget = target as SkillsUI;

        // Call your custom function here
        // Exemple : scriptTarget.YourFunctionName();
        scriptTarget.DisplayUISkill();
    }
}
