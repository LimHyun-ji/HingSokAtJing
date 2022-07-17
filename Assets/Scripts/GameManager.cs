using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private SoundManager soundManager = null;
    // private int[] randomVoice = new int[8];
    // private int[] randomVoiceSelect = new int[8];
    // System.Random randomObj = new System.Random();
    public static GameManager Instance()
    {
        return _instance;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (this != _instance)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void Start()
    {
        currentSetOfExercise = 0;
        currentTimesOfExercise = 0;
        // for (int i = 0; i < 8; i++) {
        //     int randomValue = randomObj.Next(10);
        //     randomVoice[i] = randomValue + 1;
        //     randomValue = randomObj.Next(3);
        //     randomVoiceSelect[i] = randomValue;
        // }
    }

    private float gameTime = 0f;
    private int[] timesOfExercise = new int[3];
    private int currentTimesOfExercise;
    private int currentSetOfExercise;
    private int maxTimesOfExercise = 10;
    private int maxSetOfExercise = 3;
    private bool grabDumbbell = false;
    private bool startExercise = false;
    private PlayerHandController playerHandController = null;
    private int randomVoiceIndex = 0;

    public GameObject TrackLineL;
    public GameObject TrackLineR;
    public GameObject StartPosL;
    public GameObject StartPosR;
    public GameObject EndPointL;
    public GameObject EndPointR;

    public void Update()
    {
        
    }

    public void addPlayerHandController(PlayerHandController _playerHandController)
    {
        playerHandController = _playerHandController;
    }

    public void addSoundManager(SoundManager _soundManager)
    {
        soundManager = _soundManager;
    }

    public void addTimesOfExercise()
    {
        currentTimesOfExercise += 1;
        Debug.Log("currentTimesOfExercise" + currentTimesOfExercise);
        // if(randomVoice[randomVoiceIndex] == currentSetOfExercise) {
        //     switch(randomVoiceSelect[randomVoiceIndex]) {
        //         case 0:
        //             EffectSound("Good");
        //             break;
        //         case 1:
        //             EffectSound("VeryGood");
        //             break;
        //         case 2:
        //             EffectSound("Mommy");
        //             break;
        //     }
        // } else {
            // EffectSound(currentSetOfExercise.ToString());
        // }
        if (currentTimesOfExercise == maxTimesOfExercise)
        {
            timesOfExercise[currentSetOfExercise] = currentSetOfExercise;
            completeSetOfExercise();
        }
    }

    public void completeSetOfExercise()
    {
        currentTimesOfExercise = 0;
        currentSetOfExercise += 1;
        Debug.Log("currentSetOfExercise" + currentSetOfExercise);
        // playerHandController.endOneSet();
        if (currentSetOfExercise == maxSetOfExercise)
        {
            completeTotalExercise();
            Debug.Log("End Exercise");
        }
        // Invoke("AgainEffect", 5f);
    }

    private void AgainEffect() {
        // EffectSound("Again");
    }

    public void completeTotalExercise()
    {
        // EffectSound("Finish");
        playerHandController.setIsExercise(false);
    }

    public void outOfTrackLine(string _position) {
        if(_position == "L") {
            StartPosL.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            TrackLineL.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            EndPointL.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        if(_position == "R") {
            StartPosR.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            TrackLineR.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            EndPointR.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }

    public void inToTrackLine(string _position) {
        if(_position == "L") {
            StartPosL.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            TrackLineL.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            EndPointL.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        if(_position == "R") {
            StartPosR.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            TrackLineR.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            EndPointR.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }

    // public void EffectSound(string _soundName, bool _isEffect = true) {
    //     if(_isEffect) {
    //         soundManager.Play(_soundName, Sound.Effect);
    //     } else {
    //         soundManager.Play(_soundName, Sound.Bgm);
    //     }
        
    // }

    public void setGrabDumbbell(bool _grab)
    {
        grabDumbbell = _grab;
        if(_grab) {
            // EffectSound("BGM", false);
        }
    }

    public void setStartExercise(bool _start)
    {
        startExercise = _start;
        // EffectSound("Start");
        //경로 띄우기
    }
}

