/* toMultiGame.c#
 * by Julian Sangillo
 * This script will navigate the player from the controls
 * scene to the multiplayer game by hitting the next button */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toMultiGame : MonoBehaviour {

    //---------------------------Declaration-------------------------
    public Button nextBtn;

    void Start () {

        //----------------------------------Initialization And Function Call------------------------------------
        nextBtn.onClick.AddListener(pongMultiplayer);


	}

    void pongMultiplayer() {

        //-------------------------------Scene Change-----------------------------------
        SceneManager.LoadScene(4, LoadSceneMode.Single);

    }
}
