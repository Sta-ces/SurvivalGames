using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullets : MonoBehaviour {

    public static Bullets instance;

    [Range(1, 50)]
    public int m_Damage = 10;


    public int DamageBullet(){
        return m_Damage;
    }


    private void Awake(){
        if( instance != null ){
            Destroy(instance);
            return;
        }

        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyPrefabs>())
        {
            EnemyPrefabs enemy = other.gameObject.GetComponent<EnemyPrefabs>();
            enemy.SetLifeEnemy(DamageBullet());
            if(enemy.GetLifeEnemy() <= 0){
                Destroy(enemy.gameObject);
            }
        }
        
        Destroy(gameObject);
    }
}
