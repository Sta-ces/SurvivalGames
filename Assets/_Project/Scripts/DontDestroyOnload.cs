using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnload : MonoBehaviour {

	void OnEnable(){ DontDestroyOnLoad(transform.gameObject); }
}
