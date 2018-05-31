using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillsUISecondChance : SkillsUI {

    public override void CustomUISkill()
    {
        base.CustomUISkill();
        
        GetComponentInChildren<Image>().fillAmount = (SecondChance.Instance.ExtraLife) ? 1 : 0;
    }
}
