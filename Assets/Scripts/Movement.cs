using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	Rigidbody2D rb;
	public Vector2 startPos, endPos, direction;
	public bool ativo = true;

	[Range(0.005f, 5f)]
	public float force = 30f;

	public float move;

	public void Awake()
	{
		ativo = true;
	}

	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		//Primeiro if para corrigir bug que contava um touch qnd saia do pause.
		if (PauseMenu.gameIsPaused == false)
		{
			ativo = true;
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && ativo == true )
		{
			startPos = Input.GetTouch(0).position;
			endPos = Input.GetTouch(0).position;			
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && ativo == true 
			&& Time.timeScale != 0 && rb.velocity.magnitude <= 0)
		{
			endPos = Input.GetTouch(0).position;
			direction = startPos - endPos;
			rb.AddForce(-direction * force);
			//if (-direction.x > 0  && -direction.y < 0)
			//{
			//	rb.velocity = new Vector2(5f, -5f);
			//}
			//rb.velocity = new Vector2(-direction.x / 1000, -direction.y / 1000);
			ativo = false;
		}
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
