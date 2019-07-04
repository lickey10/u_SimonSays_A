using UnityEngine;
using System.Collections;

public class JackDemo : MonoBehaviour {

	public Animator animator;
	public string AnimationCategory1 = "Common";//walk, run, idle, jump
	public string AnimationCategory2 = "Fun";//cool things to show off
	public string AnimationCategory3 = "Character Specific";//Custom movements for this character - fight, dance, climb, box, etc
	
	void OnGUI() {

		GUILayout.BeginVertical("box");
		if (GUILayout.Button(AnimationCategory1)) {
			if(animator.GetBool("Common"))
				animator.ResetTrigger("Common");
			else
			{
				animator.ResetTrigger("Fun");
				animator.ResetTrigger("Character Specific");
				animator.SetTrigger("Common");
			}
		}
		if (GUILayout.Button(AnimationCategory2)) {
			if(animator.GetBool("Fun"))
				animator.ResetTrigger("Fun");
			else
			{
				animator.ResetTrigger("Character Specific");
				animator.ResetTrigger("Common");
				animator.SetTrigger("Fun");
			}
		}
		if (GUILayout.Button(AnimationCategory3)) {
			if(animator.GetBool("Character Specific"))
				animator.ResetTrigger("Character Specific");
			else
			{
				animator.ResetTrigger("Common");
				animator.ResetTrigger("Fun");
				animator.SetTrigger("Character Specific");

				//the animation isn't moving past this one if the bool "Character Specific" is set.  
				//It should because I have it set to move on after the first animation is done but it doesn't want to.  
				//I wonder if it's because the first animation is so small
				//this will set the bool "Character Specific" to false
				Invoke("resetTrigger",2f);
			}
		}
		GUILayout.FlexibleSpace();
		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
	}

	private void resetTrigger()
	{
		animator.ResetTrigger("Character Specific");
	}
}
