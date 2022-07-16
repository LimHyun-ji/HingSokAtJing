using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    float mouseDistance = 10;
    public string controllerName = "";
    private PlayerHandController otherHand;
    private string otherHandName;
    //private bool isDumbelGripRight;
    //private bool isDumbelGripLeft;
    protected int count = 0;
    protected Vector3 initialDumbbellPos;
    protected bool isDumbbellGrip;
    protected bool isOutofTrackLine;
    protected bool isExercise;
    protected bool isOnStartPos;
    protected bool reachEndPoint;

    // private GameObject dumbbell;
    // private GameObject startPoint;
    // private GameObject endPoint;//이거는 안보이게 

    // private GameObject trackLine;
    // private GameObject warningSignGoRight;
    // private GameObject warningSignGoLeft;

    public GameObject startPoint;
    public GameObject endPoint;
    public GameObject trackLine;
    public GameObject dumbbell;
    public GameObject otherHandObject;

    void Start()
    {
        GameManager.Instance().addPlayerHandController(gameObject.GetComponent<PlayerHandController>());
        otherHandName = (controllerName == "L" ? "Right" : "Left");
        otherHand = otherHandObject.GetComponent<PlayerHandController>();
        initialDumbbellPos = dumbbell.transform.position;
        startPoint.SetActive(false);
        endPoint.SetActive(false);
        trackLine.SetActive(false);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(isDumbbellGrip);
            dumbbell.transform.position = initialDumbbellPos;
            otherHand.dumbbell.transform.position = otherHand.initialDumbbellPos;
            dumbbell.gameObject.transform.parent = null;
            otherHand.dumbbell.gameObject.transform.parent = null;

            isDumbbellGrip = false;
            otherHand.isDumbbellGrip = false;

            trackLine.SetActive(false);
            endPoint.SetActive(false);

            GameManager.Instance().setGrabDumbbell(false);

        }
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseDistance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    private void OnTriggerEnter(Collider other) //항상 양쪽 다 체크해야 함
    {
        if (other.gameObject.name.Contains("Dumbel" + controllerName))
        {
            isDumbbellGrip = true;
            dumbbell.transform.SetParent(gameObject.transform);//이건 나중에 없애줌

            if (otherHand.isDumbbellGrip)
            {
                GameManager.Instance().setGrabDumbbell(true);
                isExercise = true;
                otherHand.startPoint.SetActive(true);
                startPoint.SetActive(true);
                Debug.Log("Grab Dumbbell" + controllerName);
            }
        }
        if(isExercise) {
            if (other.gameObject.name.Contains("StartPos" + controllerName))
            {
                isOnStartPos = true;
                startPoint.SetActive(false);
                if (otherHand.isOnStartPos)
                {
                    trackLine.SetActive(true);
                    endPoint.SetActive(true);
                    otherHand.trackLine.SetActive(true);
                    otherHand.endPoint.SetActive(true);
                    Debug.Log("Start");
                    if (count == 0)
                    {
                        GameManager.Instance().setStartExercise(true);
                    }
                    else
                    {
                        GameManager.Instance().addTimesOfExercise();
                    }
                    count++;
                    otherHand.count++;
                }
            }
            if (other.gameObject.name.Contains("TrackLine" + controllerName))
            {
                //트랙 경로가 닿은 만큼 줄어들기(Slider처럼)
                isOutofTrackLine = false;
                isOnStartPos = false;

            }
            if (other.gameObject.name.Contains("EndPoint" + controllerName))
            {
                Debug.Log("End");
                startPoint.SetActive(true);
                reachEndPoint = true;
            }
        }
        

    }
    private void OnTriggerExit(Collider other) // 한쪽만 벗어나도 호출
    {
        if (other.gameObject.name.Contains("Dumbel" + controllerName))//덤벨을 놓으면
        {
            isDumbbellGrip = false;
            trackLine.SetActive(false);
            endPoint.SetActive(false);
            GameManager.Instance().setGrabDumbbell(false);
        }
        if(isExercise) {
            if (other.gameObject.name.Contains("TrackLine" + controllerName))
            {
                //트랙 경로를 벗어나면
                //Warning
                isOutofTrackLine = true;
            }
        }

    }

    public void setIsExercise()
    {
        isExercise = false;
    }
}
