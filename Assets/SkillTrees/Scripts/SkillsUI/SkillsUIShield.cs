using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillsUIShield : SkillsUI
{

    public override void CustomUISkill()
    {
        base.CustomUISkill();

        GetComponentInChildren<Image>().fillAmount = (FindObjectOfType<Shield>().gameObject.activeSelf) ? 1 : 0;
    }
}
