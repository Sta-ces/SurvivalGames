using UnityEngine;

public class Bullets : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
            Destroy(other.gameObject);
    }
}
