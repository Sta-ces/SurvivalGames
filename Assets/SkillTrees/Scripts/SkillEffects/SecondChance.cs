using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecondChance : SimpleSingleton<SecondChance> {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    public bool CheckSkill()
    {
        bool active = false;

        if(SkillScript != null)
        {
            if (SkillScript.skill.Enable)
            {
                if(extraLife)
                {
                    active = true;
                    ActiveSkill();
                }
            }
        }

        return active;
    }

    private void ActiveSkill()
    {
        print("Second Chance!");
        OnActivate.Invoke();
    }

    private bool extraLife = true;
    public void SetExtraLife(bool _extraLife)
    {
        extraLife = _extraLife;
    }

    public void KillAllEnemies()
    {
        foreach(EnemyControler enemy in GameObject.FindObjectsOfType<EnemyControler>())
            enemy.Killed();
    }
}
