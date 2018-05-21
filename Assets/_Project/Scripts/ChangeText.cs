using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ChangeText : MonoBehaviour {

    public string On;
    public string Off;

    void LateUpdate()
    {
        if (On != "" && Off != "")
            GetComponent<Text>().text = (GamePadInputs.Instance.IsGamepad) ? On : Off;
    }
}
