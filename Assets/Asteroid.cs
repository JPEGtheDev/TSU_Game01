using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{

		//sprite determined by magnitude and if the magnitude is greater than 2 ish the asteroid isnt destroyed
		public int magnitude;
		private bool dead = false;
		SpriteRenderer sr;
		public Sprite[] small;
		public Sprite[] med;
		public Sprite[] large;
		int speed = 3;
		protected int health;
		float[] sizes = {.6f,1f,2f};

		void Start ()
		{
				sr = GetComponent<SpriteRenderer> ();
				randomize (true);
				
		}
	
		void ApplyDamage (GameObject collision)
		{

				if (!dead) {
						//if bullets collide with the enemy...
						if (collision.tag == "PlayerBullets") {
								//health is reduced by 10		
								health -= 10;
								if (health > 0) {
										magnitude--;
										randomize (false);
										valueStore.valStore.addScrap (1);
										valueStore.valStore.addScore (100);
								}
								
						}
						if (collision.tag == "Player" || collision.tag == "Enemies") {
								health -= 10;
								if (health <= 0) {
										StartCoroutine (Death ());
								}
								magnitude--;
								randomize (false);
						}
				}
		}

		IEnumerator Death ()
		{
				dead = true;
				yield return new WaitForEndOfFrame ();
				Destroy (this.gameObject);
		}

		void Update ()
		{
				if (!dead) {
						//if the enemy's health is equal to or below 0...
						if (health <= 0) {
								kill ();
						}
						if (transform.position.y < -6) {
								StartCoroutine (Death ());
						}
				}
		}

		void FixedUpdate ()
		{
				//rigidbody2D.velocity = -Vector2.up * speed * Random.Range (1, 10);
				transform.position = new Vector3 (transform.position.x, transform.position.y - speed * Time.deltaTime, 1);
		}

		void kill ()
		{
				if (!dead) {
						valueStore.valStore.addScrap (1);
						valueStore.valStore.addScore (100);
						StartCoroutine (Death ());
				}
		}

		void randomize (bool mag)
		{

				if (mag == true) {
						magnitude = Random.Range (0, 3);
				}
				int temp;
				if (magnitude == 0) {
						temp = Random.Range (0, small.Length - 1);
						sr.sprite = small [temp];
						health = 10;
				} else if (magnitude == 1) {
						temp = Random.Range (0, med.Length - 1);
						sr.sprite = med [temp];
						health = 20;
				} else if (magnitude == 2) { 		
						temp = Random.Range (0, large.Length - 1);
						
						sr.sprite = large [temp];
						health = 30;
				} else {
						magnitude = 0;
						temp = 0;
						sr.sprite = small [temp];
						health = 10;
				}
				(collider2D as CircleCollider2D).radius = sizes [magnitude];
				
		}
}
