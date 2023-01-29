using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedMenu : MonoBehaviour
{
    public GameManager GM;
    public PauseMenu PM;

    public void retry()
    {
        PM.GetComponent<PauseMenu>().Retry();
        GM.failed.SetActive(false);
    }

    public void returnSong()
    {
        PM.GetComponent<PauseMenu>().returnSelection();
        GM.failed.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
