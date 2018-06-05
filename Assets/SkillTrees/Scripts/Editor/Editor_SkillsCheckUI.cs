using UnityEditor;

[CustomEditor(typeof(SkillsCheckUI))]
public class Editor_SkillsCheckUI : Editor {

	public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SkillsCheckUI scriptTarget = target as SkillsCheckUI;

        // Call your custom function here
        // Exemple : scriptTarget.YourFunctionName();
        scriptTarget.CheckUISkills();
    }
}
