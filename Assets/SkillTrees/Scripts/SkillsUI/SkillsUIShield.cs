using UnityEngine;
using UnityEngine.UI;

public class SkillsUIShield : SkillsUI
{
    public GameObject Shield;

    public override void CustomUISkill()
    {
        base.CustomUISkill();

        GetComponentInChildren<Image>().fillAmount = (Shield.activeSelf) ? 1 : 0;
    }
}
