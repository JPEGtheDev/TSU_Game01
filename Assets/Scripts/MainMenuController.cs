using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
		void Start ()
		{
				StartCoroutine (delayedStart ());
		}

		IEnumerator delayedStart ()
		{
				yield return new WaitForSeconds (30.0f);
				Application.LoadLevel ("HighScoreWOentry");
		}
}
