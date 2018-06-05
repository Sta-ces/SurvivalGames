using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SkillUsedText : MonoBehaviour {
    
    public float TimeBeforeDisappear = 1;

	public void SkillUsed(SkillsButtons skill)
    {
        StartCoroutine(Waiting(skill.skill.Name));
    }

    private IEnumerator Waiting(string _name)
    {
        GetComponent<Text>().text = _name;
        yield return new WaitForSeconds(TimeBeforeDisappear);
        GetComponent<Text>().text = "";
    }
}
