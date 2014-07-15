using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Linq;

public class valueStore : MonoBehaviour
{
		public static valueStore valStore;
		public struct highScores
		{
				public int highScore;
				public string name;
				public bool ishigh;
		}
		void Awake ()
		{
				if (valStore == null) {
						DontDestroyOnLoad (this.gameObject);
						valStore = this;
				} else if (valStore != this) {
						Destroy (this.gameObject);
				}
		}

		void Start ()
		{
				load ();
				tempHighScore = highScor [0].highScore;
		}

		void Update ()
		{
				if (score >= tempHighScore) {
						tempHighScore = score;
				}
				if (Input.GetButtonDown ("InsertCoin")) {
						insertCoin ();
				}
				if (Input.GetButtonDown ("Player1")) {
						if (playing == false && credits > 0) {
								removeCoin ();
								playing = true;
								setLevel (1);
								setLives (2);
								setScore (0);
								setScrap (0);
								Application.LoadLevel (1);
						}
				}
		}

		public static highScores[] highScor = new highScores[10];
		protected int score = 0;
		protected int credits = 0;
		protected int scrap = 0;
		protected int lives = 0;
		protected int LowestHighScore;
		protected int level = 0;
		protected int tempHighScore = 0;
		protected int wepLevel = 0;
		protected int nameToSet;
		public bool playing = false;
		public bool gameOver = false;

		public int getScore ()
		{
				return score;
		}

		public void setScore (int score)
		{
				this.score = score;
		}

		public void setHighName (string name)
		{
				highScor [nameToSet].name = name;
				highScor [nameToSet].ishigh = false;
				save ();
		}

		public int getCredits ()
		{
				return credits;
		}

		public void insertCoin ()
		{
				this.credits += 1;
		}

		public void removeCoin ()
		{
				this.credits -= 1;
		}

		public int getScrap ()
		{
				return scrap;
		}
	
		public void setScrap (int scrap)
		{
				this.scrap = scrap;
		}

		public void addScrap (int scrap)
		{
				this.scrap += scrap;
		}

		public void setLives (int lives)
		{
				this.lives = lives;
		}

		public int getLives ()
		{
				return lives;
		}

		public void setLevel (int level)
		{
				this.level = level;
		}

		public int getLevel ()
		{
				return level;
		}

		public void setWeaponLevel (int wepLevel)
		{
				this.wepLevel = wepLevel;
		}

		public int getWeaponLevel ()
		{
				return this.wepLevel;
		}

		public void addLives (int lives)
		{
				this.lives += lives;
		}

		public int getHighScore ()
		{
				return tempHighScore;
		}

		public int getScores (int number)
		{
				return highScor [number].highScore;
		}

		public string getNames (int number)
		{
				return highScor [number].name;
		}

		public void addLevel ()
		{
				this.level++;
		}

		public void addScore (int score)
		{
				this.score += score;
		}

		public bool checkScore ()
		{
				if (score >= highScor [9].highScore && score != 0) {
						highScor [9].highScore = this.score;
						highScor [9].name = "you!";
						highScor [9].ishigh = true;
						sortScores ();
						for (int i = 0; i < 9; i++) {
								if (highScor [i].ishigh == true) {
										nameToSet = i;
										break;
								}
						}
						return true;
				} else {
						sortScores ();
						return false;
				}
		}

		private static void save ()
		{
				SaveData a = new SaveData ();
				a.hs = new int[highScor.Length];
				a.names = new string[highScor.Length];

				for (int i = 0; i < highScor.Length; i++) {
						a.hs [i] = highScor [i].highScore; 
						a.names [i] = highScor [i].name;
						highScor [i].ishigh = false;
				}
				BinaryFormatter formatter = new BinaryFormatter ();
				FileStream file = File.Create (Application.persistentDataPath + "/HighScores.dat");
				formatter.Serialize (file, a);
				file.Close ();
		}

		private static void load ()
		{
				if (File.Exists (Application.persistentDataPath + "/HighScores.dat")) {
						BinaryFormatter formatter = new BinaryFormatter ();
						FileStream file = File.Open (Application.persistentDataPath + "/HighScores.dat", FileMode.Open);
						SaveData a = (SaveData)formatter.Deserialize (file);
						file.Close ();
						highScor = new highScores[a.names.Length];
						for (int i = 0; i < a.names.Length; i++) {
								highScor [i].highScore = a.hs [i];  
								highScor [i].name = a.names [i];
								highScor [i].ishigh = false;
						}
				} else {
						purgeSave ();
				}
		}

		public static void  purgeSave ()
		{
				purgeHighScores ();
				save ();
		}

		public static void purgeHighScores ()
		{
				
				for (int i = 0; i < highScor.Length; i++) {
						highScor [i].highScore = 0;
						highScor [i].name = null;
				}
				highScor [0].highScore = 10000;
				highScor [0].name = "JPEG";
				highScor [1].highScore = 6900;
				highScor [1].name = "MSTRSHD0";

		}

		public static void sortScores ()
		{
				Array.Sort (highScor, (x,y) => y.highScore.CompareTo (x.highScore));
		}


}

[Serializable]
class SaveData
{
		public int[] hs;
		public string[] names;
}
