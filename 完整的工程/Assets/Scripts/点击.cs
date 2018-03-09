//1030514412 刘金玲

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .UI ;

namespace Lyu
{
	public class 点击 : MonoBehaviour {
		public KeyCode _Key = KeyCode.A;
		public GameObject _Prefab;
		public int _Count = 1;
		public GameObject Prefab1;
		bool a=true  ;
		private GameObject newObj;
		public  Slider  slider;

		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}
		int b=0;
		[ContextMenu("点击")]
		public void onclick(){

			if (b==0) {
				newObj = 
					Instantiate (_Prefab) as GameObject;
				newObj.name ="耳朵";
				newObj.transform.SetParent (transform);
				newObj.transform.localPosition = new Vector3(0,0,0);
				b++;
				//a = false;
				Debug .Log ("a=true---false");
			}else if (b==1){
				//Destroy (transform.Find ("耳朵").gameObject );
				DestroyObject (newObj);
				b = 0;
				Debug .Log ("a=false---true");
				//	a = true;
			}
			//a = true;
		}

		public void changesize(){
			newObj.transform.localScale = new Vector3 (slider.value, slider.value, 1);
		}
	}


}
