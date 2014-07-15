using UnityEngine;
using System.Collections;

public class displayBoard : MonoBehaviour
{
		public enum Choice
		{
				Score,
				Credits,
				HighScore,
				Lives,
				Level,
				Scrap
		}
		private int value;
		public Choice choice;
		public bool doubleDigit = false;

		void Start ()
		{
		}

		void Update ()
		{
				if (choice == Choice.Score) {
						value = valueStore.valStore.getScore ();
				}
				if (choice == Choice.Scrap) {
						value = valueStore.valStore.getScrap ();
				}
				if (choice == Choice.HighScore) {
						value = valueStore.valStore.getHighScore ();
				}
				if (choice == Choice.Credits) {
						value = valueStore.valStore.getCredits ();
				}
				if (choice == Choice.Lives) {
						value = valueStore.valStore.getLives ();
				}
				if (choice == Choice.Level) {
						value = valueStore.valStore.getLevel ();
				}
				if (doubleDigit == false) {
						GetComponent<TextMesh> ().text = "0" + value.ToString ();
				}
				if (doubleDigit == true) {
						if (value < 9) {
								GetComponent<TextMesh> ().text = "0" + value.ToString ();
						}
						if (value > 9) {
								GetComponent<TextMesh> ().text = value.ToString ();
						}
				}
		}
}
