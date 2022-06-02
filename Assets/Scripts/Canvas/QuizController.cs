using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class QuizController : MonoBehaviour
{
    //Total questions and unanswered
    public Question[] questions;
    private static List<Question> unanswered;

    //Current question
    private Question currentQuest;

    //Question text elements
    public Text factText;
    public Text extraText;

    //Button elements and response text placement
    public Button[] optionBtns;
    public Text[] responsesText;

    //Correct answer
    private string correctResponse;
    private Text actualResponse;

    //Answers color
    public Color rightAnswer;
    public Color wrongAnswer;

    //Next panel gameobject
    public GameObject nextPanel;

    //GameController object
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        if (unanswered == null || unanswered.Count == 0)
        {
            unanswered = questions.ToList<Question>();
        }

        SetNextQuestion();
    }

    void SetNextQuestion()
    {
        
        //Update current quest with first option on unanswered list
        currentQuest = unanswered[0];

        //Update text
        factText.text = MainTranslate.Fields[currentQuest.fact];

        //If there is extra data update it
        if (extraText)
        {
            extraText.text = "";

            foreach (string dataID in currentQuest.extraData)
            {
                extraText.text += "- " + MainTranslate.Fields[dataID] + Environment.NewLine;
            }
        }

        //If there are various options set the buttons
        if (optionBtns.Length > 0)
        {
            SetButtons();
        }
    }

    void SetButtons()
    {
        int i = 0;

        //Check every option in question and update the button
        foreach (var but in currentQuest.options)
        {
            //Change button name
            optionBtns[i].gameObject.name = but.name;

            //Change option button content
            if (optionBtns[i].transform.Find("Text"))
            {
                optionBtns[i].transform.Find("Text").GetComponent<Text>().text = MainTranslate.Fields[but.fact];
            }

            //If there are images change the values
            if (but.image)
            {
                optionBtns[i].GetComponent<Image>().sprite = but.image;
                SpriteState st = new SpriteState();
                st.highlightedSprite = but.highLightImage;
                st.pressedSprite = but.highLightImage;
                optionBtns[i].spriteState = st;
                optionBtns[i].targetGraphic = optionBtns[i].GetComponent<Image>();
            }

            //Change response text
            if (responsesText.Length > 0)
            {
                responsesText[i].text = MainTranslate.Fields[but.response];
                responsesText[i].gameObject.name = but.name;
            }

            //Change color for the correct and incorrect answers
            if (but.isCorrect)
            {
                correctResponse = but.name;

                ColorBlock colorVar = optionBtns[i].colors;
                colorVar.selectedColor = rightAnswer;

                optionBtns[i].colors = colorVar;
            }
            else
            {
                ColorBlock colorVar = optionBtns[i].colors;
                colorVar.selectedColor = wrongAnswer;

                optionBtns[i].colors = colorVar;
            }

            i++;
        }
    }

    //When a button is selected check answer
    public void selectButton(GameObject button)
    {
        //If there are response placements put it in the front
        if (responsesText.Length > 0)
        {
            //Get the clicked button
            foreach (var res in responsesText)
            {
                if (res.name == button.name)
                {
                    actualResponse = res;
                }
            }

            button.SetActive(false);
            actualResponse.gameObject.SetActive(true);
        }

        //Check if answer was correct or not
        if (button.name == correctResponse)
        {
            unanswered.Remove(currentQuest);

            if (unanswered.Count > 0)
            {
                CorrectAnswer(button);
            }
            else
            {
                LastAnswer();
            }
        }
        else
        {
            StartCoroutine(WrongAnswer(button));
        }
    }

    IEnumerator WrongAnswer(GameObject button)
    {
        yield return new WaitForSeconds(2f);

        if (responsesText.Length > 0)
        {
            actualResponse.gameObject.SetActive(false);
            button.SetActive(true);
        }

        /*if (this.transform.parent.name == "FinalTest")
        {
            EventSystem.current.SetSelectedGameObject(null);
            unanswered.Remove(currentQuest);

            SetNextQuestion();
        }*/
    }

    void CorrectAnswer(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);

        SetNextQuestion();

        button.SetActive(true);
        actualResponse.gameObject.SetActive(false);
    }


    void LastAnswer()
    {
        if (nextPanel)
        {
            nextPanel.SetActive(true);

            /*if (nextPanel.GetComponent<Instructions>())
            {
                nextPanel.GetComponent<Instructions>().finishInstruction();
            }*/

            this.gameObject.SetActive(false);
        }
        else
        {
            gameController.finishMission();
        }

    }
}
