﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnload : MonoBehaviour {

	void Start(){ DontDestroyOnLoad(transform.gameObject); }
}
