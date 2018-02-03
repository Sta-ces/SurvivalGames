using UnityEngine;

public class Shoots : MonoBehaviour {

    public GameObject m_PrefabsBullet;
    public Transform m_LocationSpawnBullet;
    [Range(1f, 10f)]
    public float m_TimeBulletDestroy = 3f;
    [Range(5f, 15f)]
    public float m_SpeedBullet = 6f;


    void Update () {
        Shoot();
	}


    private void Shoot()
    {
        if (CharacterControlerGames.PlayerInput.GetButtonDown("Shoot"))
        {
            GameObject bullet = Instantiate(m_PrefabsBullet,m_LocationSpawnBullet.position,m_LocationSpawnBullet.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * m_SpeedBullet;
            Destroy(bullet,m_TimeBulletDestroy);
        }
    }
}
