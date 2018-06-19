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
    public bool ExtraLife { get { return extraLife; } }
    public void SetExtraLife(bool _extraLife)
    {
        extraLife = _extraLife;
    }

    public void KillAllEnemies()
    {
        EnemyControler[] enemies = FindObjectsOfType<EnemyControler>();
        foreach (EnemyControler enemy in enemies)
        {
            if (enemy.tag == "Enemy")
            {
                if(Endofthegame.Instance.SkillScript.skill.Enable)
                    Score.Instance.ReduceScore();

                enemy.Killed();
            }
        }
    }
}
