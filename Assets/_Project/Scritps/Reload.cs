using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour {

    [Header("Text Locations")]
    public Text m_TextAmmo;
    public Text m_TextMaxAmmo;
    public Slider m_SlideTimeReload;

    [Header("Informations")]
    [Range(5, 50)]
    public int m_MaxAmmo = 10;
    [Range(1, 5)]
    public float m_TimeReload = 2;

    public static int Shoots;
    public static int MaxAmmo;
    public static bool isShoot = true;

    private void Awake()
    {
        Shoots = m_MaxAmmo;
        MaxAmmo = m_MaxAmmo;
    }

    private void Update()
    {
        if ( Shoots <= 0 || CharacterControlerGames.PlayerInput.GetButtonDown("Reload") )
            StartCoroutine("Reloading");

        DisplayAmmo();
    }

    private IEnumerator Reloading()
    {
        isShoot = false;
        yield return new WaitForSeconds(m_TimeReload);
        Shoots = m_MaxAmmo;
        DisplayAmmo();
        isShoot = true;
    }

    private void DisplayAmmo()
    {
        m_TextAmmo.text = Shoots.ToString();
        m_TextMaxAmmo.text = m_MaxAmmo.ToString();
    }
}
