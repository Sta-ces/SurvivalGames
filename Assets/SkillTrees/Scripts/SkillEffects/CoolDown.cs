using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoolDown : MonoBehaviour {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    public void CheckSkill()
    {
        if (SkillScript != null)
        {
            if (SkillScript.skill.Enable)
            {
            }
        }
    }

    private void ActiveSkill()
    {
        print("CoolDown!");
        OnActivate.Invoke();
    }
}
