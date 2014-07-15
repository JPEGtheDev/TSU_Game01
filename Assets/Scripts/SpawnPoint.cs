using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
		GameObject playerPrefab;

		void Start ()
		{
				playerPrefab = Resources.Load<GameObject> ("Prefabs/player");
				respawnPlayer ();
		}

		void Update ()
		{
	
		}

		public void respawnPlayer ()
		{
				Instantiate (playerPrefab, transform.position, transform.rotation);
		}
}
