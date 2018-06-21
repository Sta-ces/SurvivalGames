using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class ChangeProfile : MonoBehaviour {

    public PostProcessingProfile DefaultProfile;

	public void ChangeTheProfile(PostProcessingProfile _profile)
    {
        GetComponent<PostProcessingBehaviour>().profile = _profile;
    }

    public void ResetProfile()
    {
        GetComponent<PostProcessingBehaviour>().profile = DefaultProfile;
    }
}
