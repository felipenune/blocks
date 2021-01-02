using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	public GameObject[] balls;

	private GameObject[] getCount;

	public float spawnTime = 1f;

	private int randomPrefab;
	public int count;

    void Start()
    {
		StartCoroutine(SpawnBalls());
	}

	private void Update()
	{
		//comando para contar quantos objetos player tem na tela, para so entao dar spawn.
		getCount = GameObject.FindGameObjectsWithTag("Player");
		count = getCount.Length;
	}

	public void Spawn()
	{
		if (count <= 0 && Input.touchCount == 0)
		{
			randomPrefab = Random.Range(0,4);
			Instantiate(balls[randomPrefab], transform.position, Quaternion.identity);
		}

	}

	IEnumerator SpawnBalls()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnTime);
			Spawn();
		}
	}
}
