using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillsButtons : MonoBehaviour {
    
    public int skillID = -1;
    public int SkillID
    {
        get { return skillID; }
        set { skillID = value; }
    }
    
    public UnityEvent OnClick;
    
	private void LateUpdate () {
        Information();

        if (Controls.ActivedSkill && selected)
            OnClick.Invoke();
    }


    public void OnPointerEnter() { selected = true; }
    public void OnPointerExit() { selected = false; }

    public void EnableSkill()
    {
        _skill = SkillTreePlayer.Instance.GetSkills[SkillID];
        if (_unlock && !_skill.AlwaysEnable) GetComponentInChildren<Toggle>().isOn = !_skill.Enable;
        else if (_skill.AlwaysEnable) GetComponentInChildren<Toggle>().isOn = true;
    }

    public void Information()
    {
        if (SkillID > -1)
        {
            _skill = SkillTreePlayer.Instance.GetSkills[SkillID];
            _unlock = _skill.RequiredLevel <= Score.Instance.GetHighscore;

            gameObject.name = "ButtonID" + SkillID;
            _skill.Unlock = _unlock;
            if (GetComponentInChildren<Text>())
            {
                GetComponentInChildren<Text>().text = _skill.RequiredLevel.ToString();
                GetComponentInChildren<Text>().gameObject.SetActive(!_unlock);
            }
            if(GetComponent<Button>())
                GetComponent<Button>().interactable = _unlock;
            if (GetComponentInChildren<Toggle>())
            {
                GetComponentInChildren<Toggle>().isOn = _skill.Enable;
                if (_skill.AlwaysEnable) GetComponentInChildren<Toggle>().gameObject.SetActive(false);
            }
        }
    }

    private Skills.Skill _skill;
    private bool _unlock = false;
    private bool selected = false;
}
