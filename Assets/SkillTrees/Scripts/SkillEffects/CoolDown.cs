using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoolDown : SimpleSingleton<CoolDown> {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    [Header("Active After")]
    public int NumberKill = 20;

    [Header("Power is Ready")]
    public UnityEvent OnReady;

    [Header("Slow")]
    [Range(1, 20)]
    public int SecondCoolDown = 5;
    [Range(1, 10)]
    public float EnemySpeed = 2f;

    [Header("UnActivate")]
    public UnityEvent OnUnActivate;

    private static int countingKill = 0;
    public static int CountingKill
    {
        get { return countingKill; }
        set { countingKill = value; }
    }

    public void ResetCountingKill() { CountingKill = 0; }

    private static bool isCoolDown = false;
    public static bool IsCoolDown
    {
        get { return isCoolDown; }
    }

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
                        StartCoroutine("ActiveSkill");
                    }
                }
            }
        }
    }

    public void ActivateSoundKill()
    {
        if(CountingKill == NumberKill)
        {
            OnReady.Invoke();
        }
    }

    private void LateUpdate()
    {
        CheckSkill();
    }

    private IEnumerator ActiveSkill()
    {
        print("CoolDown!");
        isCoolDown = true;
        float defaultSpeed = EnemyCapacity.SpeedEnemy;
        EnemyCapacity.SpeedEnemy = EnemySpeed;

        OnActivate.Invoke();

        yield return new WaitForSeconds(SecondCoolDown);
        isCoolDown = false;

        EnemyCapacity.SpeedEnemy = (defaultSpeed == 0) ? EnemyControler.Instance.SpeedBase : defaultSpeed;

        OnUnActivate.Invoke();

        print("Fin CooldDown");
    }
}
