using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


// Der Manager sorgt dafür, dass der Splashscreen nach Ende der Animation ausgeschaltet wird
[RequireComponent(typeof(VideoPlayer))]
public class SplashScreenManager : MonoBehaviour {

    // Der Canvas mit allen anderen UI-Dingen
    [SerializeField]
    private GameObject UICanvas;
    // Siehe Tooltip
    [SerializeField]
    [Tooltip("Wenn dieser Mode an ist, wird der Splashscreen nicht immer abgespielt, damit man ihn sich nicht immer beim austesten anderer Sachen anschauen muss")]
    private bool developmentMode;

    // Je nachdem, ob der developmentMode an ist, wird der Splashscreen abgespielt oder nicht
	private void Awake() {
        if (!developmentMode) {
            UICanvas.SetActive(false);
        } else {
            transform.parent.gameObject.SetActive(false);
        }
    }

    // Die Methode DeactivateObject wird zum LoopPointReachedEvent der VideoPlayers hinzugefügt und wird dann ausgeführt, sobald das Video fertig abgespielt ist
    void Update() {
        VideoPlayer player = GetComponent<VideoPlayer>();
        player.loopPointReached += DeactivateObject;
    }

    // Wird aufgerufen, sobald der Splashscreen fertig ist und deaktiviert ihn
    private void DeactivateObject(VideoPlayer player) {
        player.targetCamera = null;
        UICanvas.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
