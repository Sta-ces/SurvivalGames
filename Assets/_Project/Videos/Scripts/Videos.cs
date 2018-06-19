using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class Videos : MonoBehaviour {

    [Header("At The End of the Video")]
    public UnityEvent EndVideo;
	
	void Update ()
    {
        long frame = GetComponent<VideoPlayer>().frame;
        long frameCount = Convert.ToInt64(GetComponent<VideoPlayer>().frameCount);

        if (frame == frameCount)
            EndVideo.Invoke();
	}
}
