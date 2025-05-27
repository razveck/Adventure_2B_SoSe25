using FMODUnity;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	public EventReference footstepEvent;

	//muss 1:1 gleich heissen wie das animation event
	public void Footstep(){
		//RuntimeManager.PlayOneShot("event:/SFX_Footsteps");
		RuntimeManager.PlayOneShot(footstepEvent);
		
		Debug.Log("footstep");
	}
}
