/* dontDestroy.c#
 * by Julian Sangillo
 * This script will make ensure that the audio source playing the
 * pong theme will remain active in each scene. */

using UnityEngine;

public class dontDestroy : MonoBehaviour {

	void Awake () {

        DontDestroyOnLoad(gameObject);
		
	}
}
