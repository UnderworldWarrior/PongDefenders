/* exitApplication.c#
 * by Julian Sangillo
 * This script will exit the game after the 'Quit Game' button
 * is pressed. */

using UnityEngine;
using UnityEngine.UI;

public class exitApplication : MonoBehaviour {

    public Button btn;

	void Start() {

        btn.onClick.AddListener(exit);

    }

    void exit() {

        Application.Quit();

    }

}
