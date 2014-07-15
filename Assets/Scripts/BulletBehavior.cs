using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour
{
		private float vertSpeed = 10f;

		void Start ()
		{
				//this sets the velocity of the bullet
				rigidbody2D.velocity = Vector2.up * vertSpeed;
		}
		//this is how long the bullet is alive for (found by trial and error)
		float aliveTime = 60;

		void FixedUpdate ()
		{
				//for every fixed frame interval alivetime is decreased
				--aliveTime;
				if (aliveTime < 0) {
						//after the counter hits 0, THIS gameObject is destroyed
						Destroy (this.gameObject);
				}

		}

		// if the bullet enters any scenario where it collides with something, this funciton runs
		void OnCollisionEnter2D (Collision2D collision)
		{
				// this checks to see if the object that is colliding with the bullet has the "BulletBounds" OR the "Enemies" tag.
				if (collision.gameObject.tag == "BulletBounds") {
						Destroy (this.gameObject);
				} else if (collision.gameObject.tag == "Enemies")
				{
						collision.transform.SendMessage ("ApplyDamage", this.gameObject);
						Destroy (this.gameObject);
				}
		}

}
