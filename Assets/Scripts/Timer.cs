using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
	public static float time = 11f;
	public GameManager gameManager;

    void Update()
    {
		time -= Time.deltaTime;
		string minutes = Mathf.Floor(time / 60).ToString("00");
		string seconds = Mathf.Floor(time % 60).ToString("00");
		GetComponent<Text>().text = string.Format("Time: {0}:{1}", minutes, seconds);

		if (time < 1f)
		{
			time = 0f;
			gameManager.GetComponent<GameManager>().GameOver();
		}
    }
}