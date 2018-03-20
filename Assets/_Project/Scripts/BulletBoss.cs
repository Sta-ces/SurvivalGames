using UnityEngine;

public class BulletBoss : MonoBehaviour {

	private void OnTriggerEnter(Collider col){
		if( col.gameObject == CharacterControler.Instance.gameObject ){
			col.gameObject.SetActive(false);
			Display.Instance.CharacterDead();
		}
		Destroy(gameObject);
	}
}
