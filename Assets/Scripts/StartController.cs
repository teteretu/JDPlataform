using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartController : MonoBehaviour {

	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Main");
        }
	}

}
