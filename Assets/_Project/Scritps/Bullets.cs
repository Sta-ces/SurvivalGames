using UnityEngine;

public class Bullets : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Destroy(other.gameObject);
            Scoring.AddScore(1);
            GameDifficulty.DifficultyProgression();
        }
        
        Destroy(gameObject);
    }
}
