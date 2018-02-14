using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

[RequireComponent(typeof(LineRenderer))]
public class Weapons : MonoBehaviour {

	[Header("Bullets")]
    public GameObject m_PrefabsBullet;
    public Transform m_LocationSpawnBullet;
    [Range(1f, 10f)]
    public float m_TimeLifeBullet = 3f;
    [Range(5f, 50f)]
    public float m_SpeedBullet = 6f;

    [Header("Text Locations")]
    public Text m_TextAmmo;
    public Text m_TextMaxAmmo;
    public Slider m_SlideTimeReload;

    [Header("Informations")]
    [Range(5, 50)]
    public int m_MaxAmmo = 10;
    [Range(1, 5)]
    public float m_TimeReload = 2;

    [Header("Laser Weapon")]
    public bool isLaser = true;
    [Range(0f, 10f)]
    public float m_laserWidthStart = 0.01f;
    [Range(0f, 10f)]
    public float m_laserWidthEnd = 0f;
    [Range(1f, 20f)]
    public float m_laserLength = 2f;
    public Material m_Material;


    public static int Ammo;


    public void ResetAmmo(){
        Ammo = m_MaxAmmo;
    }

    public int GetAmmo(){
        return Ammo;
    }

    public int GetMaxAmmo(){
        return m_MaxAmmo;
    }

    public void SetIsShoot(bool _shoot){
        isShoot = _shoot;
    }


    private void Awake(){
	    if( isLaser )
	    	LaserWeapon();
	    else
	    	GetComponent<LineRenderer>().enabled = false;

    	Ammo = m_MaxAmmo;
    }

    private void Update(){
    	Player input = CharacterControlerGames.PlayerInput;

    	if( isShoot ){
	    	if( input.GetButtonDown("Shoot") ){
	    		Shoot();
	    		Ammo--;
	    	}

	    	if( Ammo <= 0 || input.GetButtonDown("Reload") ){
	    		StartCoroutine("Reloading");
	    	}
	    }

    	DisplayAmmo();
    }


    private void Shoot()
    {
        GameObject bullet = Instantiate(m_PrefabsBullet, m_LocationSpawnBullet.position, m_LocationSpawnBullet.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * m_SpeedBullet;
        Destroy(bullet, m_TimeLifeBullet);
    }

    private IEnumerator Reloading(){
        isShoot = false;
        yield return new WaitForSeconds(m_TimeReload);
        ResetAmmo();
        isShoot = true;
    }

    private void LaserWeapon()
    {
        laserLineRenderer = GetComponent<LineRenderer>();
        laserLineRenderer.startWidth = m_laserWidthStart;
        laserLineRenderer.endWidth = m_laserWidthEnd;
        Vector3 positionLaser = new Vector3(0, 0, m_laserLength);
        laserLineRenderer.SetPosition(1, positionLaser);
        laserLineRenderer.material = m_Material;
        laserLineRenderer.useWorldSpace = false;
        laserLineRenderer.alignment = LineAlignment.View;
    }

    private void DisplayAmmo()
    {
        m_TextAmmo.text = Ammo.ToString();
        m_TextMaxAmmo.text = m_MaxAmmo.ToString();
        m_SlideTimeReload.value = Calcul.PercentageToValue(Ammo,m_MaxAmmo);
    }


    private LineRenderer laserLineRenderer;
    private bool isShoot = true;
}
