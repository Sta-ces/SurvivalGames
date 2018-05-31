using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Endofthegame : MonoBehaviour {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    public void CheckSkill()
    {
        if (SkillScript != null)
        {
            if (SkillScript.skill.Enable)
            {
                Spawning.Instance.Infinite = false;
                if (Spawning.Instance.IsFinish)
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
        print("End of the game!");
        OnActivate.Invoke();
    }
}
