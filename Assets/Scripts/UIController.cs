using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Text secText;
    Text setText;
    Text countText;

    private void Start() 
    {
        secText=transform.Find("Time").Find("Text").gameObject.GetComponent<Text>();
        setText=transform.Find("Set").Find("Text").gameObject.GetComponent<Text>();
        countText=transform.Find("Count").Find("Text").gameObject.GetComponent<Text>();
    }
    private void Update() 
    {
        secText.text=((int)GameManager.Instance().gameTime).ToString()+ " sec";
        setText.text=GameManager.Instance().currentSetOfExercise.ToString()+ " set";
        countText.text=GameManager.Instance().currentTimesOfExercise.ToString() +" times";
    }

    
}
