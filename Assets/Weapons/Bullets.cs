using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullets : Singleton<Bullets> {

    [Range(1, 50)]
    public int m_Damage = 10;

    [Header("Kill :")]
    public List<string> m_TagEnemiesToKill;


    public int DamageBullet(){
        return m_Damage;
    }


    private void OnTriggerEnter(Collider col)
    {
        if ( m_TagEnemiesToKill.Contains(col.gameObject.tag) )
        {
            if(col.gameObject.GetComponent<EnemyControler>())
                col.gameObject.GetComponent<EnemyControler>().SetLifeEnemy(m_Damage);
        }
        
        Destroy(gameObject);
    }
}
