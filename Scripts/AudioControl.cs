using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {

	public AudioSource ButtonHoverClickSrc;
	public AudioClip ButtonHover;
	public AudioClip ButtonClick;

	public void HoverSound(){
		ButtonHoverClickSrc.PlayOneShot (ButtonHover);
	}
	public void ClickSound(){
		ButtonHoverClickSrc.PlayOneShot (ButtonClick);
	}
}
