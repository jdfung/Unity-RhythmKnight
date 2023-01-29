using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    //Song
    public AudioSource Music;
    AudioClip AC;
    public float timer = 0.0f;
    public int timerSec = 0;

    //scroller
    public bool startPlaying;
    public BeatScroller BS;
    public static GameManager instance;

    //Combo
    public int currentCombo = 0;
    public Text comboText;

    //calculate results
    public float totalNotes;
    public float totalMiss = 0;
    public float totalPerfectHit = 0;
    public float highestCombo = 0;

    //HealthBar
    public int maxHealth = 10;
    public int currentHealth;
    public Health healthbar;

    //Animation Trigger
    public int comboCount = 0;
    public bool hit = false;
    public bool miss = false;
    public bool isdead = false;
    public bool songEnd = false;

    //Result
    public GameObject resultScreen;
    public Text perfectHitText, missText, highestComboText, percentText, rankText;

    //failed
    public GameObject failed;

    //Tutorial box
    public GameObject tutbox;

    //character animation
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        comboText.text = "Combo: 0";

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        AC = Music.clip;

    }

    public void beatHit()
    {
        miss = false;
        totalPerfectHit++;
        currentCombo++;
        comboCount++;
        comboText.text = "Combo: " + currentCombo;
        if (comboCount == 5)
        {
            hit = true;
            currentHealth = currentHealth + 1;
            if(currentHealth > 10)
            {
                currentHealth = 10;
            }
            comboCount = 0;
        }
        else
        {
            hit = false;
        }

        healthbar.SetHealth(currentHealth);
    }



    public void beatMiss()
    {
        hit = false;
        currentCombo = 0;
        comboCount = 0;
        totalMiss++;
        comboText.text = "Combo: " + currentCombo;
        decreaseHealth(2);
        healthbar.SetHealth(currentHealth);
        
        StartCoroutine(missTrigger());

    }

    private IEnumerator missTrigger()
    {
        miss = true;
        yield return new WaitForSeconds(0.3f);
        miss = false;
    }

    private IEnumerator MonsterdeathTrigger()
    {
        songEnd = true;
        yield return new WaitForSeconds(0.75f);
        songEnd = false;
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }

    public void decreaseHealth(int decre)
    {
        currentHealth -= decre;

        if(currentHealth <= 0 && !isdead)
        {
            //anim.Play("Knight_death");
            
            StartCoroutine(fail());
        }
      
    }

    private IEnumerator fail()
    {
        anim.Play("Knight_death");
        isdead = true;
        yield return new WaitForSeconds(0.75f);
        
        failed.SetActive(true);
        Music.Stop();
        Time.timeScale = 0f;
    }

    public void resetDefault()
    {
        Music.Stop();
        //BS.transform.position = BS.originalPos;
        // BS.hasStarted = false;
        anim.Play("Knight_idle");
        hit = false;
        miss = false;
        songEnd = false;
        isdead = false;
        timer = 0.0f;
        totalMiss = 0;
        totalPerfectHit = 0;
        currentCombo = 0;
        comboCount = 0;
        highestCombo = 0;
        currentHealth = 10;
        healthbar.SetHealth(currentHealth);
        StopAllCoroutines();
        startPlaying = false;
    }

    public void presentResult()
    {
        StartCoroutine(MonsterdeathTrigger());
        resultScreen.SetActive(true);
        perfectHitText.text = totalPerfectHit.ToString() + "/ " + totalNotes.ToString();
        missText.text = totalMiss.ToString();
        highestComboText.text = highestCombo.ToString();

        float percentHit = (totalPerfectHit / totalNotes) * 100f;

        percentText.text = percentHit.ToString("F1") + "%";

        string rankVal = "F";

        if (percentHit > 40)
        {
            rankVal = "E";
            if (percentHit > 55)
            {
                rankVal = "D";
                if (percentHit > 65)
                {
                    rankVal = "C";
                    if (percentHit > 75)
                    {
                        rankVal = "B";
                        if (percentHit > 85)
                        {
                            rankVal = "A";
                            if (percentHit > 95)
                            {
                                rankVal = "S";
                                if (percentHit == 100)
                                {
                                    rankVal = "SS";
                                }
                            }
                        }
                    }
                }
            }
        }

        rankText.text = rankVal;
    }

    // Update is called once per frame
    void Update()
    {
        if (Music.isPlaying)
        {
            timer += Time.deltaTime;
            timerSec = (int)timer;
        }
        if (!startPlaying)
        {
            tutbox.SetActive(true);
            if(Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
            {
                startPlaying = true;
                BS.hasStarted = true;
                Music.Play();
            }
        }else
        {
            tutbox.SetActive(false);

            if(timerSec >= (int)Music.clip.length && !resultScreen.activeInHierarchy)
            {
                presentResult();  
            }
        }

        if(currentCombo > highestCombo)
        {
            highestCombo = currentCombo;
        }
    }
}
