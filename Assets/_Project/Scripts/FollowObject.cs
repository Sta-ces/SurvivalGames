using UnityEngine;

public class FollowObject : MonoBehaviour {

    public Transform ObjectToFollow;

    [Header("Coordonates")]
    public bool x = true;
    public bool y = true;
    public bool z = true;


    public void Follow()
    {
        if(ObjectToFollow != null)
        {
            Vector3 pos = transform.position;

            pos.x = (x) ? ObjectToFollow.position.x : pos.x;
            pos.y = (y) ? ObjectToFollow.position.y : pos.y;
            pos.z = (z) ? ObjectToFollow.position.z : pos.z;

            transform.position = pos;
        }
    }

    private void Update()
    {
        Follow();
    }
}
