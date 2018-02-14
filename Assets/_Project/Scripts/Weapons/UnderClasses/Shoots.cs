using UnityEngine;

public class Shoots : Weapons {

    public void Shoot()
    {
        GameObject bullet = Instantiate(m_PrefabsBullet, m_LocationSpawnBullet.position, m_LocationSpawnBullet.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * m_SpeedBullet;
        Destroy(bullet, m_TimeBulletDestroy);
    }
}
