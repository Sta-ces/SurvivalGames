using UnityEngine;
using UnityEngine.Events;

public class Shockwave : MonoBehaviour {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    [Header("Active After")]
    public int NumberKill = 30;

    [Header("Objects to Destroy in Range")]
    [Range(1, 20)]
    public float RangeToDestroy = 2f;

    private static int countingKill = 0;
    public static int CountingKill
    {
        get { return countingKill; }
        set { countingKill = value; }
    }

    public void CheckSkill()
    {
        if (SkillScript != null)
        {
            if (SkillScript.skill.Enable)
            {
                if (CountingKill >= NumberKill)
                {
                    if (Controls.Shockwave)
                    {
                        ActiveSkill();
                    }
                }
            }
        }
    }

    private void Update()
    {
        CheckSkill();
    }

    private void ActiveSkill()
    {
        print("Shockwave!");

        EnemyControler[] enemies = FindObjectsOfType<EnemyControler>();

        foreach(EnemyControler enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if(distance <= RangeToDestroy)
            {
                enemy.Killed();
            }
        }

        OnActivate.Invoke();
    }
}
