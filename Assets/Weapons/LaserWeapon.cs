using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserWeapon : MonoBehaviour {

    [Header("Laser Weapon")]
    [Range(0f, 10f)]
    public float m_laserWidthStart = 0.01f;
    [Range(0f, 10f)]
    public float m_laserWidthEnd = 0f;
    [Range(1f, 20f)]
    public float m_laserLength = 2f;
    public Material m_Material;


    public void CreateLaserWeapon()
    {
        LineRenderer laserLineRenderer = GetComponent<LineRenderer>();
        laserLineRenderer.startWidth = m_laserWidthStart;
        laserLineRenderer.endWidth = m_laserWidthEnd;
        Vector3 positionLaser = new Vector3(0, 0, m_laserLength);
        laserLineRenderer.SetPosition(1, positionLaser);
        laserLineRenderer.material = m_Material;
        laserLineRenderer.useWorldSpace = false;
        laserLineRenderer.alignment = LineAlignment.View;
    }


    private void Start(){
	    CreateLaserWeapon();	    	
    }
}
