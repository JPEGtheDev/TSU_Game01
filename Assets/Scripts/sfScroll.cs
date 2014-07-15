using UnityEngine;
using System.Collections;

public class sfScroll : MonoBehaviour
{
		public sfRandom randomizer;
		public int speedMod = 1;
		float fixedSpeed = 0.64f;
		float speed;

		void Start ()
		{

		}

		void FixedUpdate ()
		{
				
				speed = fixedSpeed * (float)speedMod;
				//for each fixed frame update... the velocity is set to go to downwards until a certain point, then it resets at the top.
				rigidbody2D.velocity = -speed * Vector2.up;
				if (transform.position.y <= -10.24f) {
						transform.position = new Vector3 (0, 15.36f, 0);
						randomizer.randomization ();
				}
		}
}
