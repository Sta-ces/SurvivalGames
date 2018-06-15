using UnityEngine.UI;

public class SkillsUISecondChance : SkillsUI {

    public override void CustomUISkill()
    {
        base.CustomUISkill();
        
        GetComponentInChildren<Image>().fillAmount = (SecondChance.Instance.ExtraLife) ? 1 : 0;
    }
}
