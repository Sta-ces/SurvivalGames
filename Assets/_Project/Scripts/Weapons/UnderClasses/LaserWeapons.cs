using UnityEngine;

public class LaserWeapons : Weapons {

    public void LaserWeapon()
    {
        laserLineRenderer = GetComponent<LineRenderer>();
        laserLineRenderer.startWidth = m_laserWidthStart;
        laserLineRenderer.endWidth = m_laserWidthEnd;
        Vector3 positionLaser = new Vector3(m_PositionStart.position.x, m_PositionStart.position.y, m_laserLength);
        laserLineRenderer.SetPosition(1, positionLaser);
        laserLineRenderer.material = m_Material;
        laserLineRenderer.alignment = LineAlignment.View;
    }


    private LineRenderer laserLineRenderer;
}
