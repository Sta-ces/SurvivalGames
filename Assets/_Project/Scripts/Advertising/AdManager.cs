using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

    [SerializeField]
    private string gameID = "2704256";

    [Header("Events")]
    [SerializeField]
    private UnityEvent OnFinished;

    private void Awake()
    {
        Advertisement.Initialize(gameID, true);
    }

    public void ShowAd(string zone = "")
    {
        StartCoroutine(WaitForAd());

        if (string.Equals(zone, "")) zone = null;

        if (Advertisement.IsReady(zone))
            Advertisement.Show(zone);
    }

    IEnumerator WaitForAd()
    {
        yield return null;

        while (Advertisement.isShowing)
            yield return null;

        OnFinished.Invoke();
    }
}
