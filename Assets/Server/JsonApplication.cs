using System;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class JsonApplication : MonoBehaviour
{
	


	public Text question;
	public Text[] programingLanguage;
	public Text[] integerValue;
	public GameObject refreshButton;


	void Start(){
		Debug.Log ("Here!!");
	}


	public void GetDataViaRefresh(){
		Debug.Log ("Here!!12");
		StartCoroutine (GetData());
		refreshButton.GetComponent<Button> ().interactable = false;
	}




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
			JsonData data = JsonMapper.ToObject(www.downloadHandler.text);
			Processjson (data);
		}

	}    
	private void Processjson(JsonData jsonString)
	{

		Debug.Log(jsonString.ToJson());
		Debug.Log (JsonMapper.ToJson (jsonString));

		Debug.Log(jsonString.GetJsonType ());

		question.text = jsonString [0]["question"].ToString ();

		JsonData choicesData = jsonString[0]["choices"];

		for (int i = 0; i < choicesData.Count; i++) {

			programingLanguage[i].text =  choicesData[i]["choice"].ToString();
			integerValue[i].text = choicesData[i]["votes"].ToString();
		}

	}

}
