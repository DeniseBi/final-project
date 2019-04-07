using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePointer : MonoBehaviour {

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
		}
	}
}
