using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TripleShoot : MonoBehaviour {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;


    private static bool isTripleShoot = false;
    public static bool IsTripleShoot
    {
        get { return isTripleShoot; }
        set { isTripleShoot = value; }
    }

    public void CheckSkill()
    {
        if (SkillScript != null)
        {
            if (SkillScript.skill.Enable)
            {
                IsTripleShoot = true;
            } else IsTripleShoot = false;
        } else IsTripleShoot = false;
    }

    private void ActiveSkill()
    {
        print("TripleShoot!");
        OnActivate.Invoke();
    }
}
