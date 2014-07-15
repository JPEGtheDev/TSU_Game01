using UnityEngine;
using System.Collections;

public class BackgroundPersistance : MonoBehaviour
{
	public static BackgroundPersistance backPers;
	
	void Awake ()
	{
		if (backPers == null)
		{
			DontDestroyOnLoad(this.gameObject);
			backPers = this;
		}
		else if(backPers != this)
		{
			Destroy(this.gameObject);
		}
	}
				
}
