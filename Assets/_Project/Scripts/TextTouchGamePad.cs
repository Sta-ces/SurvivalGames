using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextTouchGamePad : MonoBehaviour {

    public enum PowerGamepad
    {
        COOLDOWN,
        SHOCKWAVE,
        SUPERTIKI
    }
    public PowerGamepad Power;

    public void ChooseInput()
    {
        string input = "";
        switch (Power)
        {
            case PowerGamepad.COOLDOWN:
                input = Controls.CoolDownTouch; break;
            case PowerGamepad.SHOCKWAVE:
                input = Controls.ShockwaveTouch; break;
            case PowerGamepad.SUPERTIKI:
                input = Controls.SuperTikiTouch; break;
            default:
                input = "NONE"; break;
        }

        if (GetComponent<Text>())
        {
            GetComponent<Text>().text = input;
        }
    }

    private void Start()
    {
        GamePadInputs.Instance.Initialize();
        ChooseInput();
    }
}
