using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollideWithDie : MonoBehaviour {

    [Header("If Collide Die")]
    [Tooltip("List Layer of enemy")]
    public LayerMask Layer;

    [Header("When Collide")]
    public UnityEvent OnCollide;

    private void OnCollisionEnter(Collision col)
    {
        if (Layer == (Layer | (1 << col.gameObject.layer)))
        {
            col.gameObject.GetComponent<EnemyControler>().Killed();
            OnCollide.Invoke();
        }
    }
}
