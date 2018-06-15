using UnityEngine.UI;

public class SkillsUICoolDown : SkillsUI {

    public override void CustomUISkill()
    {
        base.CustomUISkill();

        GetComponentInChildren<Image>().fillAmount = Calcul.ValueToPercentage(CoolDown.CountingKill, CoolDown.Instance.NumberKill) / 100;
    }
}
