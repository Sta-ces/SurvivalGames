using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillsButtons : Skills {
    
    public UnityEvent OnClick;


    public override void EffectSkill()
    {
        base.EffectSkill();
    }


    private void Start()
    {
        Information();
    }

    private void LateUpdate () {
        if (Controls.ActivedSkill && selected)
            OnClick.Invoke();
    }


    public void OnPointerEnter() { selected = true; }
    public void OnPointerExit() { selected = false; }

    public void EnableSkill()
    {
        if (skill.Unlock && !skill.AlwaysEnable) skill.Enable = !skill.Enable;
        Information();
    }

    public void Information()
    {
        bool _unlock = skill.RequiredLevel <= Score.Instance.GetHighscore;
            
        skill.Unlock = _unlock;
        if (GetComponentInChildren<Text>())
        {
            GetComponentInChildren<Text>().text = skill.RequiredLevel.ToString();
            GetComponentInChildren<Text>().gameObject.SetActive(!_unlock);
        }
        if(GetComponent<Button>())
            GetComponent<Button>().interactable = _unlock;
        if (GetComponentInChildren<Toggle>())
        {
            GetComponentInChildren<Toggle>().isOn = skill.Enable;
            if (skill.AlwaysEnable) GetComponentInChildren<Toggle>().gameObject.SetActive(false);
        }
    }
    
    private bool selected = false;
}
