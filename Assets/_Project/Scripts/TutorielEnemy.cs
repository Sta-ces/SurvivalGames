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

    public bool Touched(bool _touched)
    {
        touched = _touched;
        return touched;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!touched)
        {
            touched = true;
            Touching.Invoke();
        }
    }
    
    private IEnumerator WaitForRespawn(float _seconds = 1f)
    {
        yield return new WaitForSeconds(_seconds);
        if (!GameManager.OnPlay)
        {
            touched = false;
            Respawn.Invoke();
        }
    }

    private bool touched = false;
}
