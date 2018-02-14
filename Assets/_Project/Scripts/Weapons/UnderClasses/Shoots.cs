using UnityEngine;

public class Shoots : Weapons {

    public static void Shoot(GameObject _bullet, Transform _locationSpawnBullet, float _speedBullet = 10f, float _timeLifeBullet = 3f)
    {
        GameObject bullet = Instantiate(_bullet, _locationSpawnBullet.position, _locationSpawnBullet.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * _speedBullet;
        Destroy(bullet, _timeLifeBullet);
    }
}
