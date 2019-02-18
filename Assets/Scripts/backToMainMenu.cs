/* backToMainMenu.c#
 * by Julian Sangillo
 * This script will change the scene to the Main Menu when
 * a back button is pressed. */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class backToMainMenu : MonoBehaviour {

    //---------------------------Declaration----------------------------
    public Button backBtn;

    void Start() {

        //---------------------------------Initialization and Function Call-----------------------------------
        backBtn = GetComponent<Button>();
        backBtn.onClick.AddListener(pongMainMenu);

    }

	void pongMainMenu() {

        try {

            Destroy(GameObject.Find("Scene Tracker"));
            Destroy(GameObject.Find("Theme Audio Source"));

        } catch (NullReferenceException) { }

        //-----------------------------------Load Scene----------------------------------------
        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }
}
