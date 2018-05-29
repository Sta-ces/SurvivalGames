using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HailToGods : SimpleSingleton<HailToGods> {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    public void CheckSkill()
    {
        if (SkillScript != null)
        {
            if (SkillScript.skill.Enable)
            {
                if (CharacterControler.Instance.DeathPlayer)
                {
                    if (Calcul.RandomNumber(1, 101) == 1)
                    {
                        ActiveSkill();
                    }
                }
            }
        }
    }

    private void ActiveSkill()
    {
        print("Hail To Gods!");
        Score.Instance.GetScore *= 2;
        OnActivate.Invoke();
    }
}
