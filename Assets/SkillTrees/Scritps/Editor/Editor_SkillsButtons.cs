using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(SkillsButtons))]
public class Editor_SkillsButtons : Editor {

	public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SkillsButtons scriptTarget = target as SkillsButtons;

        // Call your custom function here
        // Exemple : scriptTarget.YourFunctionName();

        Skills.Skill scriptSkill = scriptTarget.skill;

        Toggle _toggleComp = scriptTarget.GetComponentInChildren<Toggle>();
        if (_toggleComp)
        {
            _toggleComp.isOn = (scriptSkill.AlwaysEnable && scriptSkill.Unlock) ? true : scriptSkill.Enable;
        }

        if (scriptSkill.Name != "")
        {
            scriptTarget.name = scriptSkill.Name.Replace(" ","");
        }
        else scriptTarget.name = "Button_Skill";

        Text _textComp = scriptTarget.GetComponentInChildren<Text>();
        if (_textComp)
        {
            if (scriptSkill.Unlock) _textComp.text = "";
            else _textComp.text = scriptSkill.RequiredLevel.ToString();
        }
    }
}
