using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private SoundManager soundManager = null;
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
    }

    public float gameTime = 0f;
    private int[] timesOfExercise = new int[3];
    public int currentTimesOfExercise;
    public int currentSetOfExercise;
    private int maxTimesOfExercise = 2;
    private int maxSetOfExercise = 3;
    private bool grabDumbbell = false;
    private bool startExercise = false;
    private PlayerHandController playerHandController = null;

    public void Update()
    {
        gameTime+=Time.deltaTime;
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
    }

    public void completeTotalExercise()
    {
        playerHandController.setIsExercise();
    }
    public void setGrabDumbbell(bool _grab)
    {
        grabDumbbell = _grab;
    }
    public void setStartExercise(bool _start)
    {
        startExercise = _start;
        //경로 띄우기
    }
}
