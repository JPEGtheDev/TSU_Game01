using UnityEngine;
using System.Collections;

public class Enemy_Type02 : MonoBehaviour
{
		Transform player;
		public float point;
		//change once you have a spawnObject
		Vector3 startingPoint;
		protected int health = 10;
		private SpriteRenderer sprRend;
		public Sprite[] deathAnim = new Sprite[7];
		private bool dead = false;
		
		void Start ()
		{
				//set target -- player
				sprRend = GetComponent<SpriteRenderer> ();
				try {
						player = FindObjectOfType<characterController> ().transform;
				} catch {
				}

		}

		public float speed = .5f;
		// Update is called once per frame
		void Update ()
		{
				if (!dead) {
						//if the enemy's health is equal to or below 0...
						if (health <= 0) {
								kill ();
						}
				}
		}

		void kill ()
		{
				if (!dead) {
						valueStore.valStore.addScrap (1);
						valueStore.valStore.addScore (100);
						StartCoroutine (Death ());
				}
		}

		void FixedUpdate ()
		{
				if (!dead) {
						if (player == null && valueStore.valStore.gameOver == false) {
								player = FindObjectOfType<characterController> ().transform;
						} else if (player != null) {
								Vector2 direction = (player.position - transform.position).normalized;
								Vector2 bottomPointA = new Vector2 (-5f, -5f).normalized;
								Vector2 bottomPointB = new Vector2 (0f, -5f).normalized;
								Vector2 bottomPointC = new Vector2 (5f, -5f).normalized;
								if (direction.y < 0) {
										rigidbody2D.AddForce (direction * speed);
										point = Random.Range (0, 3);
								} else {
					
										if (point == 0) {
												rigidbody2D.AddForce (bottomPointA * speed);
										} else if (point == 1) {
												rigidbody2D.AddForce (bottomPointB * speed);
										} else if (point == 2) {
												rigidbody2D.AddForce (bottomPointC * speed);
										}
								}
								if (transform.position.y < -5) {
										rigidbody2D.velocity = new Vector2 (0, 0).normalized;
										startingPoint = new Vector3 (transform.position.x, 9, 1);
										transform.position = startingPoint;
								}
				
						} else {
								player = this.transform;
						}
				}
		}

		void OnCollisionEnter2D (Collision2D collision)
		{
				if (!dead) {
						//if bullets collide with the enemy...
						if (collision.gameObject.tag == "PlayerBullets") {
								//health is reduced by 10			
								health -= 10;
						}
			if (collision.gameObject.tag == "Player"|| collision.gameObject.tag == "Enemies") {
								//the enemy was destroyed without the player gaining points		
								die ();
						}
				}
		}

		void die ()
		{
				StartCoroutine (Death ());
		}
	
		IEnumerator Death ()
		{
				dead = true;
				Destroy (this.collider2D);
				sprRend.sprite = deathAnim [0];
				yield return new WaitForSeconds ((float)1.0 / 21);
				sprRend.sprite = deathAnim [1];
				yield return new WaitForSeconds ((float)1.0 / 21);
				sprRend.sprite = deathAnim [2];
				yield return new WaitForSeconds ((float)1.0 / 21);
				sprRend.sprite = deathAnim [3];
				yield return new WaitForSeconds ((float)1.0 / 21);
				sprRend.sprite = deathAnim [4];
				yield return new WaitForSeconds ((float)1.0 / 21);
				sprRend.sprite = deathAnim [5];
				yield return new WaitForSeconds ((float)1.0 / 21);
				sprRend.sprite = deathAnim [6];
				yield return new WaitForSeconds ((float)1.0 / 21);
				Destroy (this.gameObject);
		}
}
