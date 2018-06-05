using UnityEngine;
using UnityEngine.UI;

public class SkillsUI : MonoBehaviour {

    public SkillsButtons SkillScript;
    public Sprite SkillImage;


    public virtual void CustomUISkill() { }

    public void UISkill()
    {
        if(SkillScript != null)
        {
            if (SkillScript.skill.Enable && SkillScript.skill.Unlock)
            {
                if (GetComponentInChildren<Image>())
                {
                    DisplayUISkill();
                    CustomUISkill();
                }
            }
        }
    }

    public void DisplayUISkill()
    {
        if (SkillImage != null && GetComponentsInChildren<Image>().Length > 0)
        {
            foreach (Image _img in GetComponentsInChildren<Image>())
                _img.sprite = SkillImage;
        }
        
        gameObject.SetActive(SkillScript.skill.Enable && SkillScript.skill.Unlock);

        if (SkillScript.skill.AlwaysEnable)
            gameObject.SetActive(false);
    }
}
