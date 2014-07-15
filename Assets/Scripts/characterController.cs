using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour
{
		// movement code improvised from http://unity3d.com/learn/tutorials/modules/beginner/2d/2d-controllers
		
		//valueStore values;
		Transform bulletSpawn;
		private GameObject bulletPrefab;
		private float horizontalDirection;
		private float verticalDirection;
		private SpriteRenderer sprRend;
		public Sprite[] PlayerMovement = new Sprite[5];
		public Sprite[] deathAnim = new Sprite[7];
		bool dead = false;
		public bool deathFinish;
		private SpawnPoint sp;
		private float wepDelay = .125f;
		private bool canfire = true;

		void Awake ()
		{
				//this sets all of the variables that need to be set at the beginning of the game
				
				//this finds the point (transform) that you need to fire bullets from
				bulletSpawn = transform.FindChild ("firePoint");
				sp = SpawnPoint.FindObjectOfType<SpawnPoint> ();
				//this loads in a prefab from the "Resources/<filepath>" directory in the assets folder
				bulletPrefab = Resources.Load<GameObject> ("Prefabs/bullet");
				//this gets the SpriteRenderer Component that is required to swap out sprites		
				sprRend = GetComponent<SpriteRenderer> ();
				
		}
		
		float maxHorizontalSpeed = 5f;
		float maxVerticalSpeed = 3f;

		void FixedUpdate ()
		{

				if (!dead) {
						horizontalDirection = Input.GetAxis ("Horizontal");
						verticalDirection = Input.GetAxis ("Vertical");
						rigidbody2D.velocity = new Vector2 (maxHorizontalSpeed * horizontalDirection, maxVerticalSpeed * verticalDirection);
				} else {
						rigidbody2D.velocity = new Vector2 (0, 0);
				}
		}

		void Update ()
		{
				if (!dead) {
						if (horizontalDirection > .5) {
								sprRend.sprite = PlayerMovement [4];
						} else if (horizontalDirection > .025) {
								sprRend.sprite = PlayerMovement [3];
						} else if (horizontalDirection < .025 && horizontalDirection > -.025) {
								sprRend.sprite = PlayerMovement [2];
						} else if (horizontalDirection < -.025 && horizontalDirection > -.5) {
								sprRend.sprite = PlayerMovement [1];
						} else if (horizontalDirection < -.5) {
								sprRend.sprite = PlayerMovement [0];
						}
						if (Input.GetButtonDown ("Fire1")) {
								if (canfire) {
										FireWep ();
										canfire = false;
										StartCoroutine (delay ());
								}
						}
				}
				
		}

		void FireWep ()
		{ 
				Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		}

		IEnumerator delay ()
		{
				yield return new WaitForSeconds (wepDelay);
				canfire = true;
		
		}

		IEnumerator Death ()
		{
				dead = true;
				Destroy (this.collider2D);
				sprRend.sprite = deathAnim [0];
				yield return new WaitForSeconds ((float)1.0 / 7);
				sprRend.sprite = deathAnim [1];
				yield return new WaitForSeconds ((float)1.0 / 7);
				sprRend.sprite = deathAnim [2];
				yield return new WaitForSeconds ((float)1.0 / 7);
				sprRend.sprite = deathAnim [3];
				yield return new WaitForSeconds ((float)1.0 / 7);
				sprRend.sprite = deathAnim [4];
				yield return new WaitForSeconds ((float)1.0 / 7);
				sprRend.sprite = deathAnim [5];
				yield return new WaitForSeconds ((float)1.0 / 7);
				sprRend.sprite = deathAnim [6];
				yield return new WaitForSeconds ((float)1.0 / 7);
				Destroy (this.gameObject);
				if (valueStore.valStore.getLives () > 0) {
						valueStore.valStore.setLives (valueStore.valStore.getLives () - 1);
						sp.respawnPlayer ();
				} else {
						valueStore.valStore.gameOver = true;
				}
		}

		void OnCollisionEnter2D (Collision2D collision)
		{
				if (!dead) {
						if (collision.gameObject.tag == "Enemies") {
								collision.transform.SendMessage ("ApplyDamage", this.gameObject);
								StartCoroutine (Death ());
						} else if (collision.gameObject.tag == "EnemyBullets") {
								StartCoroutine (Death ());
						}
				}
		}
}