using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;


//public class parseJSON
//{
//	public string question;
//	public string published_at;
//	public ArrayList choices;
//}
public class NewBehaviourScript : MonoBehaviour
{
	// Sample JSON for the following script has attached.
	IEnumerator Start()
	{
		string url = "https://private-5b1d8-sampleapi187.apiary-mock.com/questions";
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null)
		{
			Processjson(www.text);
		}
		else
		{
			Debug.Log("there is some ERROR: " + www.error);
		}        
	}    
	private void Processjson(string jsonString)
	{
		Debug.Log ("ravi");
		Debug.Log (jsonString);
		JsonData jsonvale = JsonMapper.ToObject (jsonString);
		Debug.Log (jsonvale);
	
//		parseJSON parsejson;
//		parsejson = new parseJSON();
//		parsejson.question = jsonvale["question"].ToString();
//		parsejson.published_at = jsonvale["ID"].ToString();
//		parsejson.choices = new ArrayList ();
//		parsejson.but_image = new ArrayList ();
//
//		for(int i = 0; i<jsonvale["buttons"].Count; i++)
//		{
//			parsejson.but_title.Add(jsonvale["buttons"][i]["title"].ToString());
//			parsejson.but_image.Add(jsonvale["buttons"][i]["image"].ToString());
		   
	}

}