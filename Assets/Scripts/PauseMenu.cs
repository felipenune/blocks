using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public static bool gameIsPaused = false;
	Animator anim;
	public GameObject resume;
	public GameObject mainMenu;
	public GameObject quit;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void Pause()
	{
		if (gameIsPaused == false)
		{
			Time.timeScale = 0f;
			anim.SetBool("Paused", true);
			resume.SetActive(true);
			mainMenu.SetActive(true);
			quit.SetActive(true);
			gameIsPaused = true;
		}
		else
		{
			Time.timeScale = 1f;
			anim.SetBool("Paused", false);
			resume.SetActive(false);
			mainMenu.SetActive(false);
			quit.SetActive(false);
			gameIsPaused = false;
		}
	}
}
