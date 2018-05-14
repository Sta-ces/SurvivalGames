using UnityEngine;

public class RotationMouse : MonoBehaviour {

	private void Update(){
		OrientationFollowMouse();
	}

    private void OrientationFollowMouse()
    {
    	//Grab the current mouse position on the screen
    	Vector3 mousePos = Input.mousePosition;
    	Vector3 vect3Mouse = new Vector3(mousePos.x,mousePos.y, mousePos.z - Camera.main.transform.position.z);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(vect3Mouse);
		//Rotates toward the mouse
		float angle = Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x))*Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, -angle ,0);
    }
}
