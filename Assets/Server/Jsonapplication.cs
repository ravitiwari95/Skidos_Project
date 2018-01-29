using System;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

/// <summary>
/// Jsonapplication.
/// </summary>
public class Jsonapplication : MonoBehaviour
{
	// Sample JSON for the following script has attached.

	//public void 
	public Text question;
	public Text[] programinglanguage;
	public Text[] integervalue;
	public GameObject refreshbutton;


	void Start(){

		Debug.Log ("Here!!");

		//StartCoroutine (GetData());
	}


	public void GetDataViaRefresh(){

		Debug.Log ("Here!!12");
		StartCoroutine (GetData());
		refreshbutton.GetComponent<Button> ().interactable = false;
	}

//	public void OnClick(){
//
//		Debug.Log ("Here!!12");
//		StartCoroutine (GetData());
//	}


	IEnumerator GetData()
	{
		Debug.Log ("Here!!");

		string url = "http://private-5b1d8-sampleapi187.apiary-mock.com/questions";
		UnityWebRequest www = UnityWebRequest.Get (url);
		yield return www.Send();

		if (www.isNetworkError)
		{

			Debug.Log(www.error);
		}
		else
		{
			Debug.Log ("Here!!");
			//Debug.Log(JsonUtility.ToJson( www.downloadHandler.text));
			JsonData data = JsonMapper.ToObject(www.downloadHandler.text);
			Processjson (data);
		}

	}    
	private void Processjson(JsonData jsonString)
	{

		Debug.Log(jsonString.ToJson());
		Debug.Log (JsonMapper.ToJson (jsonString));

		/**		JsonData jdata = */Debug.Log(jsonString.GetJsonType ());
		//Debug.Log (jdata.ToJson());
		question.text = jsonString [0]["question"].ToString ();

		JsonData choicesData = jsonString[0]["choices"];

		for (int i = 0; i < choicesData.Count; i++) {

			programinglanguage[i].text =  choicesData[i]["choice"].ToString();
			integervalue[i].text = choicesData[i]["votes"].ToString();
		}

	}

}