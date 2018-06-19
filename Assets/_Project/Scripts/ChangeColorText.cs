using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ChangeColorText : MonoBehaviour {

    public Color NewColor;

	public void ChangeColor()
    {
        GetComponent<Text>().color = NewColor;
    }

    public void ResetColor()
    {
        GetComponent<Text>().color = baseColor;
    }


    private void Awake()
    {
        baseColor = GetComponent<Text>().color;
    }

    private Color baseColor;
}
