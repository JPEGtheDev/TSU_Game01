using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
		int TotalEnemies;
		bool asteroids = false;
		bool Enemy_Type01 = false;
		bool Enemy_Type02 = false;
		GameObject asteroid;
		bool canSpawn = true;
		int BaseLevelEnemies = 30;
		float maxDelay = 2.0f;

		void Awake ()
		{

				TotalEnemies = BaseLevelEnemies;
				asteroids = true;

				asteroid = Resources.Load<GameObject> ("Prefabs/Asteroid");
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (valueStore.valStore.gameOver == false && TotalEnemies > 0 && canSpawn == true) {
						canSpawn = false;
						StartCoroutine (randomSpawn ());
				}
				if (TotalEnemies == 0) {
						valueStore.valStore.addLevel ();
						BaseLevelEnemies += 10;
						TotalEnemies = BaseLevelEnemies;
						maxDelay -= .05f;
				}
		}

		IEnumerator randomSpawn ()
		{
				float waitTime = Random.Range (.1f, .9f);
				yield return new WaitForSeconds (waitTime);
				int enemy = Random.Range (0, 3);
				Vector3 spawnPoint = new Vector3 (Random.Range (-3.7f, 3.7f), 6, 1);
				if (enemy == 0 && asteroids == true) {
						Instantiate (asteroid, spawnPoint, new Quaternion ());
						TotalEnemies--;
				} else if (enemy == 1 && Enemy_Type01 == true) {
						//spawn Enemy_Type01
				} else if (enemy == 2 && Enemy_Type02 == true) {
						//spawn Enemy_Type02
				}
				canSpawn = true;

		}
}
