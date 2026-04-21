using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LobbyInfoSlides : MonoBehaviour
{
    [System.Serializable]
    public class Slide
    {
        public string title;
        [TextArea(4, 8)] public string description;
        public Sprite image;
    }

    public Slide[] slides;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Image procedureImage;

    int index = 0;

    void Start() => ShowSlide(0);

    public void Next()
    {
        index = (index + 1) % slides.Length;
        ShowSlide(index);
    }

    public void Previous()
    {
        index = (index - 1 + slides.Length) % slides.Length;
        ShowSlide(index);
    }

    void ShowSlide(int i)
    {
        titleText.text = slides[i].title;
        descriptionText.text = slides[i].description;
        procedureImage.sprite = slides[i].image;
    }
}
