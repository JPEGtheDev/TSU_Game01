using UnityEngine;
using System.Collections;

public class HighScoreScreenBehavior : MonoBehaviour
{
		public bool entry = false;

		void Awake ()
		{
				if (entry == false) {
						StartCoroutine (loadMain ());
				}
		}

		IEnumerator loadMain ()
		{
				yield return new WaitForSeconds (10.0f);
				Application.LoadLevel ("MainMenu");
		}
}
