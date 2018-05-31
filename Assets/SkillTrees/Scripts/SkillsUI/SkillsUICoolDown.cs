using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillsUICoolDown : SkillsUI {

    public override void CustomUISkill()
    {
        base.CustomUISkill();

        GetComponentInChildren<Image>().fillAmount = Calcul.ValueToPercentage(CoolDown.CountingKill, CoolDown.Instance.NumberKill) / 100;
    }
}
