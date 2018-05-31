using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillsUI : MonoBehaviour {

    public SkillsButtons SkillScript;
    public Sprite SkillImage;

    [Header("Dev")]
    public bool Test = false;


    public virtual void CustomUISkill() { }

    public void UISkill()
    {
        if(SkillScript != null)
        {
            if (SkillScript.skill.Enable && SkillScript.skill.Unlock)
            {
                if (GetComponentInChildren<Image>())
                {
                    CustomUISkill();
                }
            }
        }
    }

    public void DisplayUISkill()
    {
        if(SkillScript != null)
        {
            if (SkillImage != null && GetComponentsInChildren<Image>().Length > 0)
            {
                foreach (Image _img in GetComponentsInChildren<Image>())
                    _img.sprite = SkillImage;
            }

            if(!Test)
                gameObject.SetActive(SkillScript.skill.Enable && SkillScript.skill.Unlock);

            if (!Test && SkillScript.skill.AlwaysEnable)
                gameObject.SetActive(false);
        }
    }

    void Start () {
        DisplayUISkill();
        UISkill();
	}
}
