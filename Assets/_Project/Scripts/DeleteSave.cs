using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeleteSave : SimpleSingleton<DeleteSave> {

    public GameObject WindowPanel;

    public UnityEvent OnAreYouSure;
    public UnityEvent OnDontDeleteSave;
    public UnityEvent OnDeleteSave;
    
    public bool IsOpen
    {
        get { return WindowPanel.activeSelf; }
    }

    void Update ()
    {
        if (GameManager.IsPaused)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.X))
            {
                print("DELETE SAVE");
                WindowPanel.SetActive(!IsOpen);
                if (IsOpen) OnAreYouSure.Invoke();
                else DontDeleteYourSave();
            }
        }
	}

    public void DontDeleteYourSave()
    {
        StartCoroutine(WaitBefore(OnDontDeleteSave));
    }

    public void DeleteYourSave()
    {
        PlayerPrefs.DeleteAll();
        StartCoroutine(WaitBefore(OnDeleteSave));
    }

    private IEnumerator WaitBefore(UnityEvent _event)
    {
        yield return new WaitForSeconds(.25f);
        _event.Invoke();
    }
}
