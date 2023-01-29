using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public SelectionManager SM;
    public BeatScroller BS;
    public GameManager GM;
    public GameObject results;
    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject[] arrayGo;


    public GameObject PauseMenuUI;

    void Start()
    {
        arrayGo = GameObject.FindGameObjectsWithTag("Activator");

        /*if (arrayGo.Length > 0)
        {
            
        }
        arrayGo = GameObject.FindGameObjectsWithTag("Activator");*/
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GM.Music.UnPause();
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GM.Music.Pause();
    }

    public void Retry()
    {
        
        foreach (GameObject go in arrayGo)
        {
            if (!go.activeInHierarchy)
            {
                go.SetActive(true);
            }
            
        }

        if(results.activeInHierarchy)
        {
            results.SetActive(false);
        }

        BS.transform.position = BS.originalPos;
        GM.resetDefault();
        PauseMenuUI.SetActive(false);
        BS.hasStarted = false;
        Time.timeScale = 1f;
    }

    public void returnSelection()
    {
        Time.timeScale = 1f;
        Retry();
        GM.gameObject.SetActive(false);
        lvl1.SetActive(false);
        lvl2.SetActive(false);
        SM.gameObject.SetActive(true);
        PauseMenuUI.SetActive(false);
        SM.audioSource.Play();
    }
 
}
