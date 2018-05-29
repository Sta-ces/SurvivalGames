using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoolDown : MonoBehaviour {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    [Header("Active After")]
    public int NumberKill = 20;

    [Header("Slow")]
    [Range(1, 20)]
    public int SecondCoolDown = 5;
    [Range(1, 10)]
    public float EnemySpeed = 2f;

    private static int countingKill = 0;
    public static int CountingKill
    {
        get { return countingKill; }
        set { countingKill = value; }
    }

    public void ResetCountingKill() { CountingKill = 0; }

    public void CheckSkill()
    {
        if (SkillScript != null)
        {
            if (SkillScript.skill.Enable)
            {
                if (CountingKill >= NumberKill)
                {
                    if (Controls.CoolDown)
                    {
                        ResetCountingKill();
                        StartCoroutine("ActiveSkill");
                    }
                }
            }
        }
    }

    private void LateUpdate()
    {
        CheckSkill();
    }

    private IEnumerator ActiveSkill()
    {
        print("CoolDown!");
        
        EnemyCapacity.SpeedEnemy = EnemySpeed;

        OnActivate.Invoke();

        yield return new WaitForSeconds(SecondCoolDown);

        EnemyCapacity.SpeedEnemy = EnemyControler.Instance.SpeedBase;

        print("Fin CooldDown");
    }
}
