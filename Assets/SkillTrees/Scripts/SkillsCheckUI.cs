using UnityEngine;

public class SkillsCheckUI : MonoBehaviour {

    public void CheckUISkills()
    {
        foreach (Transform child in transform)
            child.GetComponent<SkillsUI>().UISkill();
    }
    
	
	void Update () {
        CheckUISkills();
	}
}
