using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Endofthegame : SimpleSingleton<Endofthegame> {

    public static bool EndGame = false;
    public void SetEndGame(bool _end)
    { EndGame = _end; }

    public SkillsButtons SkillScript;

    [Header("Activate")]
    public UnityEvent OnActivate;

    [Header("Active After")]
    public int NumberKill = 50;

    [Header("Finish the Game")]
    public UnityEvent OnFinish;


    [Header("Super Tiki")]
    public UnityEvent OnSuperPower;

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
        if (!EndGame && Spawning.Instance.IsFinish && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            print("FINISH!!!");
            OnFinish.Invoke();
        }
    }

    public void SuperTiki()
    {
        StartCoroutine("SuperTikiPower");
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
        GameObject Charact = CharacterControler.Instance.gameObject;
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float enemySpeed = EnemyCapacity.SpeedEnemy;

        while (Enemies.Length > 0)
        {
            EnemyCapacity.SpeedEnemy = 0.25f;
            foreach(GameObject enemy in Enemies)
            {
                Charact.transform.LookAt(enemy.transform);
                Weapons.Instance.AutomaticShooting();
                yield return new WaitForSeconds(AutomaticShoot.Instance.CoolDownShoot);
            }
        }
        EnemyCapacity.SpeedEnemy = enemySpeed;
    }

    private void Update()
    {
        if (PlayerPrefs.GetString("SuperTikiPower","false").ToLower() == "true" && Controls.SuperTiki)
        {
            print("Super Tiki!");
            OnSuperPower.Invoke();
        }
        
        if(FindObjectsOfType<Spawning>().Length > 0)
            FinishIt();
    }
}
