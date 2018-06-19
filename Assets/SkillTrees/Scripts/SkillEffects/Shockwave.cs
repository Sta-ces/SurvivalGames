using UnityEngine;
using UnityEngine.Events;

public class Shockwave : SimpleSingleton<Shockwave> {

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

    public void ResetCountingKill() { CountingKill = 0; }

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

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, CharacterControler.Instance.transform.position);
            if(distance <= RangeToDestroy)
            {
                if (enemy.GetComponent<EnemyControler>())
                {
                    if (Endofthegame.Instance.SkillScript.skill.Enable)
                        Score.Instance.ReduceScore();

                    enemy.GetComponent<EnemyControler>().Killed();
                }
            }
        }

        OnActivate.Invoke();
    }
}
