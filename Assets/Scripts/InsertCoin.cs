using UnityEngine;
using System.Collections;

public class InsertCoin : MonoBehaviour
{

		public static InsertCoin inscn;
		private TextMesh mr;

		void Awake ()
		{
				if (inscn == null) {
						DontDestroyOnLoad (this.gameObject);
						inscn = this;
						mr = GetComponent<TextMesh> ();
				} else if (inscn != this) {
						Destroy (this.gameObject);
				}
		}
	
		void Update ()
		{
				if (valueStore.valStore.playing == false) {
						if (valueStore.valStore.getCredits () == 0) {
								mr.text = "Insert Coin";

						} else if (valueStore.valStore.getCredits () >= 0) {
								mr.text = "Press Play";
						} else {
								mr.text = "WTF";
						}
				} else {
						mr.text = "";
				}
		}
}
