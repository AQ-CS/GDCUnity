using UnityEngine.UI;
using UnityEngine;
using TMPro; 

public class scoreScript : MonoBehaviour
{
    public static int scoreV=0;
    public TMP_Text score; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score= GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text= scoreV.ToString();
    }
}
