using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SkillDisplayNumberActivate))]
public class Editor_SkillDisplayNumberActivate : Editor {

	public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SkillDisplayNumberActivate scriptTarget = target as SkillDisplayNumberActivate;

        // Call your custom function here
        // Exemple : scriptTarget.YourFunctionName();
        scriptTarget.ChangeTextNumber();
    }
}
