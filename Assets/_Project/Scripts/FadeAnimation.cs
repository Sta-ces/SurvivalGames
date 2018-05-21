using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimation : MonoBehaviour {

    public List<Image> ListImagesToFade;

    public float SecondAfterNextImage = 0.5f;

    IEnumerator Start()
    {
        while (ListImagesToFade.Count > 0)
        {
            foreach(Image _img in ListImagesToFade)
            {
                StartCoroutine(FadeImage(_img));
                yield return new WaitForSeconds(SecondAfterNextImage);
            }
        }
    }

    IEnumerator FadeImage(Image img)
    {
        // fade from opaque to transparent
        if (img.color.a > 0.1f)
        {
            // loop over 1 second backward
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
