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


    private void OnTriggerEnter(Collider other)
    {
        if ( m_TagEnemiesToKill.Contains(other.gameObject.tag) )
        {
            Destroy(other.gameObject);
            //HitEnemy(other.gameObject);
        }
        
        Destroy(gameObject);
    }
}
