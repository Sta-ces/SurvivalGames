using UnityEngine.UI;

public class SkillsUIShockwave : SkillsUI
{

    public override void CustomUISkill()
    {
        base.CustomUISkill();

        GetComponentInChildren<Image>().fillAmount = Calcul.ValueToPercentage(Shockwave.CountingKill, Shockwave.Instance.NumberKill) / 100;
    }
}
