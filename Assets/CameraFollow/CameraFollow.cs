using UnityEngine;

public class CameraFollow : MonoBehaviour {
    
    public Transform m_Target;

    [Header("Zoom")]
    [Range(5f, 20f)]
    public float m_Higher = 10f;
    [Range(5f, 20f)]
    public float m_Distance = 10f;


    void LateUpdate () {
        PositionCamera();
	}

    public void PositionCamera()
    {
        Vector3 position = new Vector3();
        position.x = m_Target.position.x;
        position.y = m_Target.position.y + m_Higher;
        position.z = m_Target.position.z - m_Distance;

        transform.position = position;
        transform.LookAt(m_Target);
    }
}
