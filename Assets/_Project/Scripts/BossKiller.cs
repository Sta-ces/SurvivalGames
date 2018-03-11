using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKiller : Singleton<BossKiller> {


	public void BossKilled(){
		Display.Instance.SetDisplayWinner(true);
	}
}
