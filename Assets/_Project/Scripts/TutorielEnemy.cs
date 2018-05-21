using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TutorielEnemy : MonoBehaviour {

    [Header("Touch Objects")]
    public UnityEvent Touching;

    [Header("Respawn")]
    public UnityEvent Respawn;

    public void Waiting(float _seconds) {
        if(!GameManager.OnPlay)
            StartCoroutine(WaitForRespawn(_seconds));
    }

    private void OnTriggerEnter(Collider other)
    {
        Touching.Invoke();
    }
    
    private IEnumerator WaitForRespawn(float _seconds = 1f)
    {
        yield return new WaitForSeconds(_seconds);
        if (!GameManager.OnPlay)
            Respawn.Invoke();
    }
}
