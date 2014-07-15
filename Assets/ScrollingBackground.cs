using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour
{

		public float scrollSpeed;
		public float tileSize;
		private Vector3 startPosition;
		private Vector2 savedOffset;

		void Start ()
		{
				startPosition = transform.position;
				savedOffset = renderer.sharedMaterial.GetTextureOffset ("_MainTex");
				
				
		}
	
		// Update is called once per frame
		void Update ()
		{
				float x = Mathf.Repeat (Time.time * scrollSpeed, tileSize * 4);
				x = x / tileSize;
				x = Mathf.Floor (x);
				x = x / 4;
				Vector2 offset = new Vector2 (x, savedOffset.y);
				renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
				float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSize);
				transform.position = startPosition + Vector3.down * newPosition;
				
		}

		void OnDisable ()
		{
				renderer.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
				//create slowdown script to crawl to a halt
		}
}
