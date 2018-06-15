using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Rewired;

public class Weapons : SimpleSingleton<Weapons> {

	[Header("Bullets")]
    public GameObject m_PrefabsBullet;
    public Transform m_LocationSpawnBullet;
    public Transform m_LocationSpawnBullet_2;
    public Transform m_LocationSpawnBullet_3;
    [Range(1f, 10f)]
    public float m_TimeLifeBullet = 3f;
    [Range(5f, 50f)]
    public float m_SpeedBullet = 6f;

    [Header("Ammos")]
    public bool isAmmo = true;
    [Range(5, 50)]
    public int m_MaxAmmo = 10;
    [Range(1, 5)]
    public float m_TimeReload = 2;

	[Header("Shoot")]
	public UnityEvent WeaponsShoot;


    public bool IsAmmo{
		get{ return isAmmo; }
		set{ isAmmo = value; }
	}

	private int m_ammo;
    public int GetAmmo{ 
		get{ return m_ammo; }
		set{ m_ammo = value; }
	}

    public int GetMaxAmmo{
		get{ return m_MaxAmmo; }
		set{ m_MaxAmmo = value; }
	}

    public float GetTimeReload {
		get{ return m_TimeReload; }
		set{ m_TimeReload = value; }
	}

	private bool isShoot = true;
    public bool IsShoot{
		get{ return isShoot; }
		set{ isShoot = value; }
	}

	public void ResetAmmo(){
		Weapons.Instance.GetAmmo = Weapons.Instance.GetMaxAmmo;
	}

	public void Shoot(GameObject _prefabs, Transform _position, float _speed = 5f, float _timeDestroy = 3f)
	{
		GameObject bullet = Instantiate(_prefabs, _position.position, _position.rotation);

		if (!bullet.GetComponent<Rigidbody>())
			bullet.AddComponent<Rigidbody>();
		
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * _speed;

		Destroy(bullet, _timeDestroy);
	}

    public void AutomaticShooting()
    {
        Shooting();
    }


    private void Awake(){
    	ResetAmmo();
    }

    private void LateUpdate(){

		if( Weapons.Instance.IsShoot ){
			if( Controls.Shoot )
            {
                if (!AutomaticShoot.Instance.IsAutoShoot) Shooting();
				if( Weapons.Instance.IsAmmo ) Weapons.Instance.GetAmmo--;

				WeaponsShoot.Invoke();
	    	}

			if( Weapons.Instance.IsAmmo )
				if( Weapons.Instance.GetAmmo <= 0 || Controls.Reload )
					if( Weapons.Instance.GetAmmo < Weapons.Instance.GetMaxAmmo )
	    				StartCoroutine("Reloading");
	    }
    }

    
    private void Shooting()
    {
        Shoot(m_PrefabsBullet, m_LocationSpawnBullet, m_SpeedBullet, m_TimeLifeBullet);
        if (TripleShoot.IsTripleShoot)
        {
            Shoot(m_PrefabsBullet, m_LocationSpawnBullet_2, m_SpeedBullet, m_TimeLifeBullet);
            Shoot(m_PrefabsBullet, m_LocationSpawnBullet_3, m_SpeedBullet, m_TimeLifeBullet);
        }
    }

    private IEnumerator Reloading(){
		Weapons.Instance.IsShoot = false;
		yield return new WaitForSeconds(Weapons.Instance.GetTimeReload);
        ResetAmmo();
		Weapons.Instance.IsShoot = true;
    }
}
