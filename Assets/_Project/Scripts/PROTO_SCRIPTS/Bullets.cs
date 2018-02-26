using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullets : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemies>())
        {
            Destroy(other.gameObject);

            Scoring.AddScore(1);
            GameDifficulty.DifficultyProgression();
        }
        
        Destroy(gameObject);
    }
}
