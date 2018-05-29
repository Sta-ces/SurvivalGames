using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShoot : MonoBehaviour {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    [Header("Shoot")]
    [Range(0, 5)]
    public float CoolDownShoot = .75f;

    public void CheckSkill()
    {
        if (SkillScript != null)
        {
            if (SkillScript.skill.Enable)
            {
                StartCoroutine("ActiveSkill");
            }
        }
    }

    private void Start()
    {
        CheckSkill();
    }

    private IEnumerator ActiveSkill()
    {
        print("Automatic Shoot!");
        while (true)
        {
            yield return new WaitForSeconds(CoolDownShoot);
            OnActivate.Invoke();
        }
    }
}
