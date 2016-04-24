using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using UnityEngine.UI;

public class Albumx
{
	public string id { get; set; }
	public string name { get; set; }
	public string coverArt { get; set; }
	//public List<Track> tracks;

}

public class Track {
	public string id { get; set; }
	public string name { get; set; }
	public string trackName { get; set; }
	public string discNumber { get; set; }
	public string previewUrl { get; set; }
}

public class RenderAlbums : MonoBehaviour {
  
	public Sprite[] albumCovers;

	// Use this for initialization
	IEnumerator Start () {
		string url = "https://vinyl-backend.herokuapp.com/spotify/albums";
		WWW www = new WWW(url);
		yield return www;

		if (www.error == null)
		{
			Process(www.text);
		}
		else
		{
			Debug.Log("ERROR: " + www.error);
		} 
	}
		
	void OnGUI() {
		if ( GUILayout.Button( "Go!" ) ) {
			
			//https://i.scdn.co/image/748976025f64f9196351a483f8b6477609f3f0ab
			//StartCoroutine( loadImages() );
		}
	}

 
	private IEnumerator Process(string json)
	{
		Albumx[] albums = JsonMapper.ToObject<Albumx[]>(json); 
		for (int i = 0; i < albums.Length; i++) {
			Debug.Log(albums [i].name);

			WWW www = new WWW(albums[i].coverArt);
			yield return www;

			//Sprite albumSprite = albumCovers[i];

			Texture2D texture = www.texture;

			Image img = this.gameObject.GetComponent<Image>();
			img.sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height),Vector2.zero);

			Debug.Log (albums [i].name);
			//GameObject newAlbum = Instantiate (gameObject);

//
//			newAlbum

		}
		//System.Console.WriteLine (albums.ToString ());

//		album = new Album();
//		album.id = jsonvale["id"].ToString(); 
//		album.name = jsonvale["name"].ToString();
//		album.coverArt = jsonvale["coverArt"].ToString();
//
//

//		for(int i = 0; i<jsonvale["buttons"].Count; i++)
//		{
//			album.but_title.Add(jsonvale["buttons"][i]["title"].ToString());
//			album.but_image.Add(jsonvale["buttons"][i]["image"].ToString());
//		}    
	}
}
