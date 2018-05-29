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
        numberSkill = EditorGUILayout.IntField("Number to create", numberSkill);
        if (GUILayout.Button("Create a Skill"))
        {
            for(int num = 0;num < numberSkill; num++)
            {
                scriptTarget.CreateSkills();
            }
        }
    }

    private int numberSkill = 1;
}
