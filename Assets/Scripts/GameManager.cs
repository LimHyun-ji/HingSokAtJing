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

    private float gameTime = 0f;
    private int[] timesOfExercise;
    private int currentTimesOfExercise;
    private int currentSetOfExercise;
    private int maxTimesOfExercise = 10;
    private int maxSetOfExercise = 3;
    private bool grabDumbbell = false;
    private bool startExercise = false;
    private PlayerHandController playerHandController = null;

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
        if (currentTimesOfExercise == maxTimesOfExercise)
        {
            timesOfExercise[currentSetOfExercise] = currentSetOfExercise;
            completeSetOfExercise();
        }
    }

    public void completeSetOfExercise()
    {
        currentSetOfExercise += 1;
        Debug.Log("currentSetOfExercise" + currentSetOfExercise);
        if (currentSetOfExercise == maxSetOfExercise)
        {
            completeTotalExercise();
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
