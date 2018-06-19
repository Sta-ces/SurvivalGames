using UnityEngine;
using UnityEngine.Events;

public class HailToGods : SimpleSingleton<HailToGods> {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    [Header("Pourcent")]
    [Range(1, 100)]
    public int PourcentActivation = 10;

    public void CheckSkill()
    {
        if (SkillScript != null)
        {
            if (SkillScript.skill.Enable)
            {
                if (CharacterControler.Instance.DeathPlayer)
                {
                    if(Score.Instance.GetScore > 0)
                    {
                        if (Calcul.RandomNumber(1, 101) <= PourcentActivation)
                        {
                            ActiveSkill();
                        }
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
