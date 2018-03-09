/*1030514411 夏文利*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeText : MonoBehaviour {
	public GameObject wenziPre;
	public GameObject wenziPre2;
	public GameObject wenziPre3;
	public GameObject wenziPre4;
	private string selfText;
//	private TextMesh text;
	private InputField inputField;

//	private GameObject[] pres;

	// Use this for initialization
	void Start () {
		GameObject[] pres = {wenziPre,wenziPre2,wenziPre3,wenziPre4};
		for (int i = 0; i < pres.Length; i++) {
			TextMesh text = pres[i].GetComponent<TextMesh> ();
			text.text = "你真美";
		}
		inputField = GetComponent<InputField> ();
	}

	public void Change () {
		GameObject[] pres = {wenziPre,wenziPre2,wenziPre3,wenziPre4};
		selfText = inputField.text;
		for (int i = 0; i < pres.Length; i++) {
			TextMesh text = pres[i].GetComponent<TextMesh> ();
			text.text = selfText;
		}
	}
}
