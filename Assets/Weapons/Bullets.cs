using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullets : SimpleSingleton<Bullets> {

    [Range(1, 50)]
    public int m_Damage = 10;

    [Header("Kill :")]
    public List<string> m_TagEnemiesToKill;


    public int DamageBullet(){ return m_Damage; }
    public List<string> GetTags(){ return m_TagEnemiesToKill; }


    private void OnTriggerEnter(Collider col)
    {
        if ( m_TagEnemiesToKill.Contains(col.gameObject.tag) )
        {
            if(col.gameObject.GetComponent<EnemyControler>())
                col.gameObject.GetComponent<EnemyControler>().SetLifeEnemy(m_Damage);

			if (col.gameObject.GetComponent<Boss>())
				col.gameObject.GetComponent<Boss>().SetLifeEnemy(m_Damage);
        }
        
        Destroy(gameObject);
    }
}
