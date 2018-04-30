using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullets : SimpleSingleton<Bullets> {

    [Range(1, 50)]
    public int m_Damage = 10;

    [Header("Kill :")]
    public List<string> m_TagEnemiesToKill;


    public int DamageBullet{
		get{ return m_Damage; }
		set{ m_Damage = value; }
	}

    public List<string> GetTags{
		get{ return m_TagEnemiesToKill; }
	}


    private void OnTriggerEnter(Collider col)
    {
		if ( Bullets.Instance.GetTags.Contains(col.gameObject.tag) )
        {
            if(col.gameObject.GetComponent<EnemyControler>())
				col.gameObject.GetComponent<EnemyControler>().LifeEnemy = Bullets.Instance.DamageBullet;

			if (col.gameObject.GetComponent<Boss> ()) {
				col.gameObject.GetComponent<Boss> ().LifeEnemy = Bullets.Instance.DamageBullet;
				col.gameObject.GetComponent<Boss> ().BossHit.Invoke ();
			}
        }
        
        Destroy(gameObject);
    }
}
