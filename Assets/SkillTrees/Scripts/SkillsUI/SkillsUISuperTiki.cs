using UnityEngine.UI;

public class SkillsUISuperTiki : SkillsUI
{

    public override void CustomUISkill()
    {
        base.CustomUISkill();
        
        GetComponentInChildren<Image>().fillAmount = Calcul.ValueToPercentage(Endofthegame.CountingKill, Endofthegame.Instance.NumberKill) / 100;
        gameObject.SetActive(Endofthegame.EndGame);
    }
}
