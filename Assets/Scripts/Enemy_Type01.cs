using UnityEngine;
using System.Collections;

public class Enemy_Type01 : MonoBehaviour
{

		protected int health = 10;
		private SpriteRenderer sprRend;
		public Sprite[] deathAnim = new Sprite[7];
		private bool dead = false;

		void Awake ()
		{
				sprRend = GetComponent<SpriteRenderer> ();
		}

		void OnCollisionEnter2D (Collision2D collision)
		{
				if (!dead) {
						//if bullets collide with the enemy...
						if (collision.gameObject.tag == "PlayerBullets") {
								//health is reduced by 10			
								health -= 10;
						}
						if (collision.gameObject.tag == "Player") {
								//the enemy was destroyed without the player gaining points		
								die ();
						}
				}
		}

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