using UnityEngine;
using UnityEngine.Events;

public class Endofthegame : MonoBehaviour {

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

    private void ActiveSkill()
    {
        print("End of the game!");
        OnActivate.Invoke();

        if (Spawning.Instance.IsFinish && FindObjectsOfType<EnemyControler>().Length <= 0)
            OnFinish.Invoke();
    }
}
