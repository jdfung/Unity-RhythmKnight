using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    //Musics
    public AudioClip Music1;
    public AudioClip Music2;
    public AudioSource audioSource;

    //song info
    public TextMeshProUGUI songName, BPM, difficulty;

    //Images
    public GameObject img1;
    public GameObject img2;

    //selection choice
    public int selectSong = 0;

    //referencing objects
    public Image background;
    public GameObject selection;
    public GameManager GM;
    public PauseMenu PM;
    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject BS1;
    public GameObject BS2;


    public void nextSong()
    {
        selectSong += 1;
        if(selectSong > 1)
        {
            selectSong = 0;
        }
    }

    public void prevSong()
    {
        selectSong -= 1;
        if(selectSong < 0)
        {
            selectSong = 1;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playMusic1()
    {
        audioSource.clip = Music1;
    }

    public void playMusic2()
    {
        audioSource.clip = Music2;
    }

    public void PlaySelect()
    {
        if(selectSong == 0)
        {
            lvl2.SetActive(false);
            GM.gameObject.SetActive(true);
            GM.resetDefault();
            lvl1.SetActive(true);
            selection.SetActive(false);
            PM.arrayGo = GameObject.FindGameObjectsWithTag("Activator");
            PM.BS = BS1.GetComponent<BeatScroller>();
            GM.BS = BS1.GetComponent<BeatScroller>();
            GM.Music.clip = Music1;
            GM.totalNotes = FindObjectsOfType<BeatObject>().Length;
        }
        else
        {
            if (selectSong == 1)
            {
                lvl1.SetActive(false);
                GM.gameObject.SetActive(true);
                GM.resetDefault();
                lvl2.SetActive(true);
                selection.SetActive(false);
                PM.arrayGo = GameObject.FindGameObjectsWithTag("Activator");
                PM.BS = BS2.GetComponent<BeatScroller>();
                GM.BS = BS2.GetComponent<BeatScroller>();
                GM.Music.clip = Music2;
                GM.totalNotes = FindObjectsOfType<BeatObject>().Length;
            }
        }

    }

    public void backToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (selectSong == 0)
        {
            songName.text = "Song: Gunjou - Yoasobi";
            BPM.text = "BPM: 135";
            difficulty.text = "Difficulty: Medium";

            img1.SetActive(true);
            img2.SetActive(false);
            
            background.color = new Color32(41, 30, 253, 100);


            if (audioSource.clip != Music1)
            {
                playMusic1();
                audioSource.Play(); 
            }
        }
        else
        {
            if (selectSong == 1)
            {
                songName.text = "Song: Kaikai Kitan - Eve";
                BPM.text = "BPM: 184";
                difficulty.text = "Difficulty: Hard";
                img2.SetActive(true);
                img1.SetActive(false);

                background.color = new Color32(0, 0, 0, 230);

                if (audioSource.clip != Music2)
                {
                    playMusic2();
                    audioSource.Play();
                }
            }
        }
    }
}
