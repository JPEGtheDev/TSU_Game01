using UnityEngine;
using System.Collections;

public class NameEntry : MonoBehaviour
{
		Vector3[] locs = new Vector3[8];
		float horizontal;
		float vertical;
		float temploc = 0;
		float tempvert = 0;
		float vertLock = -3.25f;
		Transform trans;
		int currentSeleciton = 0;
		char[] nme = new char[8];
		int[] charSelect = new int[8];
		TextMesh[] entry;
		char[] validChars = {
				' ',
				'a',
				'b',
				'c',
				'd',
				'e',
				'f',
				'g',
				'h',
				'i',
				'j',
				'k',
				'l',
				'm',
				'n',
				'o',
				'p',
				'q',
				'r',
				's',
				't',
				'u',
				'v',
				'w',
				'x',
				'y',
				'z',
				'1',
				'2',
				'3',
				'4',
				'5',
				'6',
				'7',
				'8',
				'9',
				'0',
				'!',
				'@',
				'#',
				'$',
				'%',
				'^',
				'&',
				'*',
				'(',
				')'
		};

		void Start ()
		{
				entry = GetComponentsInChildren<TextMesh> ();
				trans = FindObjectOfType<HighScoreArrowController> ().transform;
				locs [0] = new Vector3 (0.2f, vertLock, 1);
				locs [1] = new Vector3 (0.52f, vertLock, 1);
				locs [2] = new Vector3 (.84f, vertLock, 1);
				locs [3] = new Vector3 (1.16f, vertLock, 1);
				locs [4] = new Vector3 (1.48f, vertLock, 1);
				locs [5] = new Vector3 (1.8f, vertLock, 1);
				locs [6] = new Vector3 (2.12f, vertLock, 1);
				locs [7] = new Vector3 (2.44f, vertLock, 1);
				trans.position = locs [0];
				for (int i = 0; i < nme.Length; i++) {
						nme [i] = ' ';
						charSelect [i] = 0;
				}
				
						
				
		}
	
		void Update ()
		{
				horizontal = Input.GetAxis ("Horizontal");
				vertical = Input.GetAxis ("Vertical");
				temploc = temploc + horizontal;
				tempvert = tempvert + vertical;
				trans.position = locs [currentSeleciton];
				if (temploc < 0) {
						temploc = 0;
				} else if (temploc < 10) {
						currentSeleciton = 0;
				} else if (temploc < 20) {
						currentSeleciton = 1;
				} else if (temploc < 30) {
						currentSeleciton = 2;
				} else if (temploc < 40) {
						currentSeleciton = 3;
				} else if (temploc < 50) {
						currentSeleciton = 4;
				} else if (temploc < 60) {
						currentSeleciton = 5;
				} else if (temploc < 70) {
						currentSeleciton = 6;
				} else if (temploc < 80) {
						currentSeleciton = 7;
				} else if (temploc > 80) {
						temploc = 80;
				}
				if (tempvert > 10) {
						if (charSelect [currentSeleciton] < validChars.Length - 1) {
								charSelect [currentSeleciton] += 1;
						} else {
								charSelect [currentSeleciton] = 0;
						}
						
						nme [currentSeleciton] = validChars [charSelect [currentSeleciton]];
						
						tempvert = 0;
				}
				if (tempvert < -10) {
						if (charSelect [currentSeleciton] > 0) {
								charSelect [currentSeleciton] -= 1;
						} else {
								charSelect [currentSeleciton] = validChars.Length - 1;
						}
						nme [currentSeleciton] = validChars [charSelect [currentSeleciton]];
			
						tempvert = 0;
				}
				entry [0].text = nme [0].ToString ();
				entry [1].text = nme [1].ToString ();
				entry [2].text = nme [2].ToString ();
				entry [3].text = nme [3].ToString ();
				entry [4].text = nme [4].ToString (); 
				entry [5].text = nme [5].ToString (); 
				entry [6].text = nme [6].ToString (); 
				entry [7].text = nme [7].ToString (); 
				if (Input.GetButtonDown ("Fire1")) {
						if (new string (nme) != "        ") {

			
		
								valueStore.valStore.setHighName (new string (nme));
								valueStore.valStore.playing = false;
								Application.LoadLevel ("HighScoreWOentry");

						}
				}
		}
}
