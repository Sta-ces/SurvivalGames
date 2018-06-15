using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ChangeText : MonoBehaviour {

    [TextArea]
    public string Gamepad;
    [TextArea]
    public string Keyboard;

    void LateUpdate()
    {
        ChangeTextElement();
    }

    public void ChangeTextElement()
    {
        if (Gamepad != "" && Keyboard != "")
            GetComponent<Text>().text = (GamePadInputs.Instance.IsGamepad) ? Gamepad : Keyboard;
    }

    public static string DeleteSpace(string _text)
    {
        string _string = _text.Replace(" ", "");
        _string = _string.Trim();
        return _string;
    }
}
