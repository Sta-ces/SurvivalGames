using System.Collections;
using UnityEngine;
using Rewired;

public class Weapons : Singleton<Weapons> {

	[Header("Bullets")]
    public GameObject m_PrefabsBullet;
    public Transform m_LocationSpawnBullet;
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


    public bool GetIsAmmo(){ return isAmmo; }
    public int GetAmmo(){ return m_ammo; }
    public int GetMaxAmmo(){ return m_MaxAmmo; }
    public float GetTimeReload(){ return m_TimeReload; }

    public void ResetAmmo(){
        m_ammo = m_MaxAmmo;
    }

    public void SetIsShoot(bool _isshoot){
        isShoot = _isshoot;
    }


    private void Awake(){
    	ResetAmmo();
    }

    private void Update(){
    	Player input = CharacterControler.Instance.GetPlayerInput();

    	if( isShoot ){
	    	if( input.GetButtonDown("Shoot") ){
	    		Shoot(m_PrefabsBullet, m_LocationSpawnBullet, m_SpeedBullet, m_TimeLifeBullet);
                if( isAmmo )
	    		    m_ammo--;
	    	}

	    	if( isAmmo && ( m_ammo <= 0 || input.GetButtonDown("Reload") ) && m_ammo < m_MaxAmmo ){
	    		StartCoroutine("Reloading");
	    	}
	    }
    }


    private void Shoot(GameObject _prefabs, Transform _position, float _speed = 5f, float _timeDestroy = 3f)
    {
        GameObject bullet = Instantiate(_prefabs, _position.position, _position.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * _speed;
        Destroy(bullet, _timeDestroy);
    }

    private IEnumerator Reloading(){
        isShoot = false;
        yield return new WaitForSeconds(this.GetTimeReload());
        ResetAmmo();
        isShoot = true;
    }


    private int m_ammo;
    private bool isShoot = true;
}
