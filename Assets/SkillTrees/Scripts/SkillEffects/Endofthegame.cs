using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Endofthegame : SimpleSingleton<Endofthegame> {
    
    public static bool EndGame
    {
        get { return PlayerPrefs.GetString("SuperTikiPower", "false").ToLower() == "true"; }
        set { PlayerPrefs.SetString("SuperTikiPower", value.ToString().ToLower()); }
    }
    public void SetEndGame(bool _end)
    { EndGame = _end; }

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    [Header("Finish the Game")]
    public UnityEvent OnFinish;


    [Header("Super Tiki")]
    public UnityEvent OnSuperPower;
    public int NumberKill = 50;
    [Range(0, 20)]
    public float SpeedShoot = 1f;
    public UnityEvent OnFinishSuperPower;

    [Header("Power is Ready")]
    public UnityEvent OnReady;

    private static bool isSuperTiki = false;
    public static bool IsSuperTiki
    {
        get { return isSuperTiki; }
        set { isSuperTiki = value; }
    }

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
                ActiveSkill();
            }
        }
    }

    public void FinishIt()
    {
        if (Spawning.Instance.IsFinish && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            print("FINISH!!!");
            OnFinish.Invoke();
        }
    }

    public void SuperTiki()
    {
        StartCoroutine("SuperTikiPower");
    }

    public void ActivateSoundKill()
    {
        if (SkillScript.skill.Enable && CountingKill == NumberKill)
        {
            OnReady.Invoke();
        }
    }

    private void ActiveSkill()
    {
        print("End of the game!");
        OnActivate.Invoke();

        Spawning.Instance.GetSecondsToSpawn = Spawning.Instance.GetMinSecondsToSpawn;
        EnemyCapacity.SpeedEnemy = EnemyControler.Instance.MaxSpeedEnemy;

        FinishIt();
    }

    private IEnumerator SuperTikiPower()
    {
        IsSuperTiki = true;

        GameManager.OnPlay = false;
        Weapons.Instance.IsShoot = false;
        GameManager.IsPaused = true;

        GameObject Charact = CharacterControler.Instance.gameObject;
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float enemySpeed = EnemyCapacity.SpeedEnemy;
        EnemyCapacity.SpeedEnemy = 0.25f;
        
        foreach (GameObject enemy in Enemies)
        {
            if(enemy != null)
            {
                Charact.transform.LookAt(enemy.transform);
                Weapons.Instance.AutomaticShooting();
                yield return new WaitForSeconds(SpeedShoot);
            }
        }

        EnemyCapacity.SpeedEnemy = enemySpeed;
        GameManager.IsPaused = false;
        Weapons.Instance.IsShoot = true;
        GameManager.OnPlay = true;

        IsSuperTiki = false;

        OnFinishSuperPower.Invoke();
    }

    private void Update()
    {
        if(PlayerPrefs.GetString("SuperTikiPower", "false").ToLower() == "true")
        {
            if(CountingKill >= NumberKill)
            {
                if (Controls.SuperTiki)
                {
                    print("Super Tiki!");
                    OnSuperPower.Invoke();
                }
            }
        }
        
        if(FindObjectsOfType<Spawning>().Length > 0)
            FinishIt();
    }
}
