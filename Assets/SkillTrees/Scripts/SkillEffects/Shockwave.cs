using UnityEngine;
using UnityEngine.Events;

public class Shockwave : MonoBehaviour {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    [Header("Objects to Destroy in Range")]
    [Range(1, 20)]
    public float RangeToDestroy = 2f;

    public void CheckSkill()
    {
        if (SkillScript != null)
        {
            if (SkillScript.skill.Enable)
            {
                if (Controls.Shockwave)
                {
                    ActiveSkill();
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
