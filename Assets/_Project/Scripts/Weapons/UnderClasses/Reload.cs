using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Reload : Weapons {

    public static int Shooting;
    public static int MaxAmmo;
    public static bool isShoot = true;

    private void Awake()
    {
        Shooting = m_MaxAmmo;
        MaxAmmo = m_MaxAmmo;
    }

    private void Update()
    {
        if ( Shooting <= 0 || CharacterControlerGames.PlayerInput.GetButtonDown("Reload") )
            StartCoroutine("Reloading");

        DisplayAmmo();
    }

    private IEnumerator Reloading()
    {
        isShoot = false;
        yield return new WaitForSeconds(m_TimeReload);
        Shooting = m_MaxAmmo;
        DisplayAmmo();
        isShoot = true;
    }

    private void DisplayAmmo()
    {
        m_TextAmmo.text = Shooting.ToString();
        m_TextMaxAmmo.text = m_MaxAmmo.ToString();
        m_SlideTimeReload.value = Calcul.PercentageToValue(Shooting,MaxAmmo);
    }
}
