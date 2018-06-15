using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShoot : SimpleSingleton<AutomaticShoot> {

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    [Header("Shoot")]
    [Range(0, 5)]
    public float CoolDownShoot = .75f;
    
    public bool IsAutoShoot
    {
        get { return SkillScript.skill.Enable; }
    }

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
        while (!CharacterControler.Instance.DeathPlayer)
        {
            yield return new WaitForSeconds(CoolDownShoot);
            if(!GameManager.IsPaused)
                OnActivate.Invoke();
        }
    }
}
