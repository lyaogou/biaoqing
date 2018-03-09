//1030514412 刘金玲

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 选择键 : MonoBehaviour {

	public GameObject 挂饰菜单,滤镜菜单;
	private List<GameObject> _菜单们 = new List<GameObject> () ;

	void Start()
	{
		_菜单们.Add (挂饰菜单);
		_菜单们.Add (滤镜菜单);

	}

	void 禁掉所有菜单 ()
	{
		foreach (GameObject 菜单 in _菜单们) {
			菜单.SetActive(false);
		}
	}

	public void 选择挂饰()
	{
		禁掉所有菜单 ();
		挂饰菜单.SetActive(true);
	}

	public void 选择滤镜()
	{
		禁掉所有菜单 ();
		滤镜菜单.SetActive(true);
	}


	public void 选择菜单(int id)
	{
		if (id == 0) {
			选择挂饰 ();
		} else if (id == 1) {
			选择滤镜 ();
		} 
	}



}
