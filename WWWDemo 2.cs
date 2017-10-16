using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
//using UnityEngine.UI;
//using System.IO;
public class WWWDemo : MonoBehaviour {
	public GameObject cube;
	public GameObject sphere;
	public Texture2D m_uoloadImage;
	public Texture2D m_downloadTexture;
	// Use this for initialization
	void Start () {
//		StartCoroutine ("downloadByFile");
//		StartCoroutine ("downFromNet");
		StartCoroutine ("TestPost");
	}

	IEnumerator downloadByFile(){
		using (WWW texture = new WWW (
			"file:///Users/admin/Desktop/01.png")) {
			yield return texture;
			cube.GetComponent<Renderer> ().material.mainTexture = texture.texture;
		}
	}

	IEnumerator downFromNet(){
		WWW data = new WWW ("https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1507885892074&di=3163b620a509738fd441e87680b16bd2&imgtype=0&src=http%3A%2F%2Fb.hiphotos.baidu.com%2Fimage%2Fpic%2Fitem%2Fdcc451da81cb39dbbf279a97d9160924aa18300f.jpg");
		yield return data;
		sphere.GetComponent<Renderer> ().material.mainTexture = data.texture;
		data.Dispose ();
	} 

	IEnumerator TestPost(){	
		string m_info = null;
		Dictionary<string ,string > hash = new Dictionary<string, string> ();
		hash.Add ("Content-Type", "application/json");
		string data="{'email':'1234@qq.com','password':'123456','phoneIdentity':'2152131t5asdasd'}";
		byte[] bs = System.Text.UTF8Encoding.UTF8.GetBytes (data);
		WWW www = new WWW ("http://123.56.50.222:8050/userLogin", bs, hash);
		yield return www;
		if (www.error!=null) {
			m_info = www.error;
		}
		m_info = www.text;
		print (m_info);
	}

	IEnumerator IRequestPNG(){
		string m_info = null;
		byte[] bs = m_uoloadImage.EncodeToPNG ();
		WWWForm form = new WWWForm ();
		form.AddBinaryData ("picture", bs, "screenshot", "image/png");
		form.AddField ("username", "zs");
		form.AddField ("pwd", "*******");
		WWW www = new WWW ("http://127.0.0.1/test.php", form);
		yield return www;
		if (www.error!=null) {
			m_info = www.error;
			yield return null;
		}
		m_downloadTexture = www.texture;
//		string m_info = null;
//		byte[] bs = m_uoloadImage.EncodeToPNG ();
//		WWWForm form = new WWWForm ();
//		form.AddBinaryData ("picture", bs, "screenshot", "image/png");
//		WWW www = new WWW ("http://127.0.0.1/test.php", form);
//		yield return www;
//		if (www.error!=null) {
//			m_info = www.error;
//			yield return null;
//		}
//
	}


	string GetURL(string mainURL,Dictionary<string,string> dic){
		StringBuilder strbuilder = new StringBuilder ();
		strbuilder.Append (mainURL).Append ("?");
		if (dic.Count!=0) {
			foreach (var item in dic) {
				strbuilder.Append (item.Key).Append ("=").Append (item.Value).Append ("&");
			}
			strbuilder.Remove (strbuilder.Length - 1, 1);
		}
		return strbuilder.ToString ();
		
	}

	// Update is called once per frame
	void Update () {
	
	}

}
