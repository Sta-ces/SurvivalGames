using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class Weapons : MonoBehaviour {

	[Header("Character")]
	public GameObject m_Character;

	[Header("Bullets")]
    public GameObject m_PrefabsBullet;
    public Transform m_LocationSpawnBullet;
    [Range(1f, 10f)]
    public float m_TimeBulletDestroy = 3f;
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
    public Transform m_PositionStart;
    [Range(0f, 10f)]
    public float m_laserWidthStart = 0.01f;
    [Range(0f, 10f)]
    public float m_laserWidthEnd = 0f;
    [Range(1f, 20f)]
    public float m_laserLength = 2f;
    public Material m_Material;
}
