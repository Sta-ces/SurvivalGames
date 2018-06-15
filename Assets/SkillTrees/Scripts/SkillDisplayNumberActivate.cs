using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SkillDisplayNumberActivate : MonoBehaviour {

	public void ChangeTextNumber()
    {
        if (GetComponent<Text>())
        {
            GetComponent<Text>().text = SkillMenuPlayer.Instance.SkillActivate + " / " + (SkillMenuPlayer.Instance.MaxSkill + 1);
        }
    }

    private void LateUpdate()
    {
        ChangeTextNumber();
    }
}
