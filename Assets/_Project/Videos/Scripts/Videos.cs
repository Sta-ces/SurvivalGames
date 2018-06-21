using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class Videos : MonoBehaviour {

    [Header("At The End of the Video")]
    public UnityEvent EndVideo;
	
	void LateUpdate ()
    {
        VideoPlayer video = GetComponent<VideoPlayer>();
        long frame = video.frame;
        long frameCount = Convert.ToInt64(video.frameCount);

        if (video.isPlaying && frame == frameCount)
        {
            print("End Video");
            EndVideo.Invoke();
        }
	}
}
