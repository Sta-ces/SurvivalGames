using UnityEngine;

public class Controls {

	private static float moveX;
	public static float MoveX{
		get{ return moveX; }
		set{ moveX = value; }
	}

	private static float moveZ;
	public static float MoveZ{
		get{ return moveZ; }
		set{ moveZ = value; }
	}

	private static float lookX;
	public static float LookX{
		get{ return lookX; }
		set{ lookX = value; }
	}

	private static float lookZ;
	public static float LookZ{
		get{ return lookZ; }
		set{ lookZ = value; }
	}

	private static bool pause;
	public static bool Pause{
		get{ return pause; }
		set{ pause = value; }
	}

	private static bool shoot;
	public static bool Shoot{
		get{ return shoot; }
		set{ shoot = value; }
	}

	private static bool reload;
	public static bool Reload{
		get{ return reload; }
		set{ reload = value; }
	}

	private static bool submit;
	public static bool Submit{
		get{ return submit; }
		set{ submit = value; }
	}

	private static bool cancel;
	public static bool Cancel{
		get{ return cancel; }
		set{ cancel = value; }
	}
}
