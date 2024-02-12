using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerScore : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        SetScoreText();
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if object that triggered is labeled PickUp
        if(other.gameObject.CompareTag("PickUp")){
            // if so add to score and update text
            score ++;
            SetScoreText();
            // display winner text when score is above [9]
            if(score > 8){
                winText.SetActive(true);
            }
            other.gameObject.SetActive(false);
        }
    }
}
