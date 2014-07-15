using UnityEngine;
using System.Collections;

//this one / idea is actually all mine (JPEG) with some help from some reference pages for syntax / usage

public class sfRandom : MonoBehaviour
{
		//create an array that will house the sprites you wish to randomize
		public Sprite[] s1 = new Sprite[8];

		void Awake ()
		{
				randomization ();
		}
		//this function randomizes the sprites used in the starfield
		public void randomization ()
		{
				//this creates an array of SpriteRenderer(s) that is equal to the object's child SpriteRenderer(s)
				SpriteRenderer[] spriteSheet = GetComponentsInChildren<SpriteRenderer> ();
				//for each element (SpriteRenderer) of the array...
				foreach (SpriteRenderer a in spriteSheet) {
						//create a random integer that is between 0 and the length of the array of Sprites you created above
						int rs = Random.Range (0, (s1.Length - 1));
						// set the sprite of the current child object selected to a pseudorandom element of the sprite array
						a.sprite = s1 [rs];
				}

		}
}
