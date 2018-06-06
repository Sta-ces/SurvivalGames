using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ChangeText : MonoBehaviour {

    [TextArea]
    public string On;
    [TextArea]
    public string Off;

    void LateUpdate()
    {
        if (On != "" && Off != "")
            GetComponent<Text>().text = (GamePadInputs.Instance.IsGamepad) ? On : Off;
    }


    public static string DeleteSpace(string _text)
    {
        string _string = _text.Replace(" ", "");
        _string = _string.Trim();
        return _string;
    }
}
