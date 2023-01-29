using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsMenu : MonoBehaviour
{
    public GameManager GM;
    public SelectionManager SM;
    public GameObject lvl1;
    public GameObject lvl2;
    public PauseMenu PM;

    public void Continue()
    {
        Time.timeScale = 1f;
        GM.gameObject.SetActive(false);
        PM.GetComponent<PauseMenu>().Retry();
        lvl1.SetActive(false);
        lvl2.SetActive(false);
        SM.gameObject.SetActive(true);
        PM.GetComponent<PauseMenu>().PauseMenuUI.SetActive(false);
        this.gameObject.SetActive(false);
        SM.audioSource.Play();
    }
}
