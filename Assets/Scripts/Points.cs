using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
	public static int points;
	public string color;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == color)
		{
			points += 1;
			Placar.score = points;
			Timer.time += 2f;
		}
		else
		{
			Timer.time -= 5f;
		}
		Destroy(this.gameObject);
	}
}
