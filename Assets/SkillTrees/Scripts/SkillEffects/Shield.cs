using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    public void CheckSkill()
    {
        if (SkillScript != null)
        {
            if (SkillScript.skill.Enable)
            {
                ActiveSkill();
            }
        }
    }


    private void Start()
    {
        CheckSkill();
    }

    private void ActiveSkill()
    {
        print("Shield!");
        OnActivate.Invoke();
    }
}
