using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillsButtons : Skills {
    
    public UnityEvent OnClick;


    public void OnPointerEnter()
    {
        selected = true;
        SkillMenuPlayer.Instance.Description(this);
    }
    public void OnPointerExit() { selected = false; }

    public void EnableSkill()
    {
        if (SkillMenuPlayer.Instance.MaxSkill < 0 || SkillMenuPlayer.Instance.SkillActivate <= SkillMenuPlayer.Instance.MaxSkill || skill.Enable)
        {
            if (skill.Unlock && !skill.AlwaysEnable) skill.Enable = !skill.Enable;
            SaveInformation(skill, skill.Name);
            Information();
        }
    }

    public void Information()
    {
        //SaveInformation(skill, skill.Name);

        skill.Unlock = PlayerPrefs.GetString(ChangeText.DeleteSpace(skill.Name) + "Unlock", "false").ToLower() == "true";
        if(!skill.Unlock)
            skill.Unlock = skill.RequiredLevel <= Score.Instance.GetHighscore;

        if (skill.Unlock)
            skill.Enable = PlayerPrefs.GetString(ChangeText.DeleteSpace(skill.Name) + "Enable", "false").ToLower() == "true";
        else skill.Enable = false;
        skill.Enable = (skill.AlwaysEnable && skill.Unlock) ? true : skill.Enable;

        Button _buttonComp = GetComponent<Button>();
        if (_buttonComp)
            _buttonComp.interactable = skill.Unlock;
        
        Toggle _toggleComp = GetComponentInChildren<Toggle>();
        if (_toggleComp)
            _toggleComp.isOn = skill.Enable;

        Text _textComp = GetComponentInChildren<Text>();
        if (_textComp)
        {
            if (skill.Unlock) _textComp.text = "";
            else _textComp.text = skill.RequiredLevel.ToString();
        }
        
        SaveInformation(skill, skill.Name);
    }


    private void OnEnable()
    {
        Information();
    }

    private void LateUpdate()
    {
        if (Controls.ActivedSkill && selected)
            OnClick.Invoke();
    }


    private bool selected = false;
}
