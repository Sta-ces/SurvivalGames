using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillsUIShockwave : SkillsUI
{

    public override void CustomUISkill()
    {
        base.CustomUISkill();

        //GetComponentInChildren<Image>().fillAmount = Calcul.ValueToPercentage(Shockwave) / 100;
    }
}
