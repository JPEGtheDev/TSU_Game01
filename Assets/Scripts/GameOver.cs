using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
		MeshRenderer mr;

		void Start ()
		{
				mr = GetComponent<MeshRenderer> ();
				mr.enabled = false;
		}

		void Update ()
		{
				if (valueStore.valStore.gameOver == true) {
						gameOver ();
				}
		}

		public void gameOver ()
		{
				mr.enabled = true;
				valueStore.valStore.gameOver = false;
				if (valueStore.valStore.checkScore ()) {
						StartCoroutine (loadHighScoresWentry ());
				} else {
						StartCoroutine (loadHighScoresWOentry ());
				}
				
				
		}

		IEnumerator loadHighScoresWentry ()
		{
				yield return new WaitForSeconds (5.0f);
				Application.LoadLevel ("HighScoreWentry");

		}

		IEnumerator loadHighScoresWOentry ()
		{
				yield return new WaitForSeconds (5.0f);
				Application.LoadLevel ("HighScoreWOentry");
				valueStore.valStore.playing = false;
		}
}
