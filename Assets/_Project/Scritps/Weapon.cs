using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Weapon : MonoBehaviour {

    [Range(0f, 10f)]
    public float m_laserWidthStart = 0.01f;
    [Range(0f, 10f)]
    public float m_laserWidthEnd = 0f;
    [Range(1f, 20f)]
    public float m_laserLength = 2f;
    public Material m_Material;

    
    void Start()
    {
        LaserWeapon();
    }


    public void LaserWeapon()
    {
        laserLineRenderer = GetComponent<LineRenderer>();
        laserLineRenderer.startWidth = m_laserWidthStart;
        laserLineRenderer.endWidth = m_laserWidthEnd;
        laserLineRenderer.SetPosition(1, new Vector3(0f, 0f, m_laserLength));
        laserLineRenderer.material = m_Material;
    }


    private LineRenderer laserLineRenderer;
}
