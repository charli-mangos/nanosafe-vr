using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SlideController : MonoBehaviour
{
    //Slide panel
    public SlideUnit[] sld;
    private static List<SlideUnit> slides;

    //Current slide active
    private SlideUnit currentSlide;

    //Current index active 
    private int index = 0;

    //Change Scene script
    public ChangeScene changeScene;

    //UI components
    public Button startButton;
    public Text tittle;
    public Text description;
    public Image img; 

    // Start is called before the first frame update
    void Start()
    {
        if (slides == null || slides.Count == 0)
        {
            slides = sld.ToList<SlideUnit>();
        }

        setNextSlide();
    }

    public void setNextSlide()
    {
        if(currentSlide != null && index + 1 < slides.Count)
        {
            index = index + 1;
        }
        else
        {
            index = 0;
        }

        currentSlide = slides[index];

        setUIComponents();
    }

    public void sePreviousSlide()
    {
        if (index > 0)
        {
            index = index - 1;
        }
        else
        {
            index = slides.Count - 1;
        }

        currentSlide = slides[index];

        setUIComponents();
    }

    public void setUIComponents()
    {
        description.text = "";

        img.sprite = currentSlide.image;

        tittle.text = MainTranslate.Fields[currentSlide.tittle];

        startButton.onClick.AddListener(delegate { changeScene.change(currentSlide.changeScene); });

        foreach (var palID in currentSlide.description)
        {
            description.text = description.text + MainTranslate.Fields[palID] + "\n" + "\n";
        }
    }
}
