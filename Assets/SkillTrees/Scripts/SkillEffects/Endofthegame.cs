using UnityEngine;
using UnityEngine.Events;

public class Endofthegame : SimpleSingleton<Endofthegame> {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    [Header("Finish the Game")]
    public UnityEvent OnFinish;

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

    public void FinishIt()
    {
        if (Spawning.Instance.IsFinish && FindObjectsOfType<EnemyControler>().Length <= 0)
            OnFinish.Invoke();
    }

    private void ActiveSkill()
    {
        print("End of the game!");
        OnActivate.Invoke();

        Spawning.Instance.GetSecondsToSpawn = Spawning.Instance.GetMinSecondsToSpawn;
        EnemyCapacity.SpeedEnemy = EnemyControler.Instance.MaxSpeedEnemy;

        FinishIt();
    }
}
