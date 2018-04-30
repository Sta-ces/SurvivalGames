using UnityEngine;

public class BulletBoss : MonoBehaviour {

	private void OnTriggerEnter(Collider col){
		if( col.GetComponent<CharacterControler>() ){
			col.GetComponent<CharacterControler>().Death.Invoke();
		}
		Destroy(gameObject);
	}
}
