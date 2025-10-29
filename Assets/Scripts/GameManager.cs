using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int timeToWait = 7;
    [SerializeField] private int fadeInTime = 7;
    [SerializeField] private GameObject endingObject;
    [SerializeField] private Image character;
    [SerializeField] private Image decor;
    
    // OBJECTS
    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    [SerializeField] private GameObject object3;
    [SerializeField] private GameObject object4;
    [SerializeField] private Sprite image1;
    [SerializeField] private Sprite image2;
    [SerializeField] private Sprite image3;
    [SerializeField] private Sprite decor1;
    [SerializeField] private Sprite decor2;
    [SerializeField] private Sprite decor3;
    
    private int eventCount = 0;
    private float timer = 0;
    private bool eventTriggered = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var color = character.color;
        color.a = 0f;
        character.color = color;

        timer = 0;
        eventTriggered = true;
    }

    private void StartEvent()
    {
        Debug.Log("COUCOU");
        character.DOFade(1f, fadeInTime).SetEase(Ease.InOutSine);

        if (eventCount == 1)
        {
            object2.gameObject.SetActive(true);
            character.sprite = image1;
        }
        else if (eventCount == 2)
        {
            object3.gameObject.SetActive(true);
            character.sprite = image2;
        }
        else if (eventCount == 3)
        {
            object4.gameObject.SetActive(true);
            character.sprite = image3;
        }
            
    }

    public void NextEvent()
    {
        eventCount++;
        if (eventCount > 3)
        {
            PlayEnding();
        }
        
        character.DOFade(0f, fadeInTime).SetEase(Ease.InOutSine);
        
        timer = 0;
        eventTriggered = false;
    }

    private void PlayEnding()
    {
        endingObject.gameObject.SetActive(true);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (!eventTriggered && timer >= timeToWait)
        {
            eventTriggered = true;
            StartEvent();
        }
    }
}
