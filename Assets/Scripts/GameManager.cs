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
    
    // OBJECTS
    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    [SerializeField] private GameObject object3;
    [SerializeField] private GameObject object4;
    
    [SerializeField] private GameObject decorObject;
    [SerializeField] private GameObject troncObject;
    [SerializeField] private GameObject groundObject;
    [SerializeField] private GameObject footsObject;
    
    // UGLY Textures
    [SerializeField] private Sprite uglyCharacter1;
    [SerializeField] private Sprite uglyCharacter2;
    [SerializeField] private Sprite uglyCharacter3;
    [SerializeField] private Material uglyDecor1;
    [SerializeField] private Material uglyDecor2;
    [SerializeField] private Material uglyDecor3;
    [SerializeField] private Material uglyTronc;
    [SerializeField] private Material uglyGround;
    [SerializeField] private Material uglyFoots;
    
    // BEAUTIFUL Textures
    [SerializeField] private Sprite image1;
    [SerializeField] private Sprite image2;
    [SerializeField] private Sprite image3;
    [SerializeField] private Material decor1;
    [SerializeField] private Material decor2;
    [SerializeField] private Material decor3;
    [SerializeField] private Material tronc;
    [SerializeField] private Material ground;
    [SerializeField] private Material foots;

    [SerializeField] private bool ugly;
    
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
        setTextures();
    }

    private void setTextures()
    {
        if (ugly)
        {
            troncObject.GetComponent<Renderer>().material = uglyTronc;
            decorObject.GetComponent<Renderer>().material = uglyDecor1;
            groundObject.GetComponent<Renderer>().material = uglyGround;
            footsObject.GetComponent<Renderer>().material = uglyFoots;
        }
        else
        {
            troncObject.GetComponent<Renderer>().material = tronc;
            decorObject.GetComponent<Renderer>().material = decor1;
            groundObject.GetComponent<Renderer>().material = ground;
            footsObject.GetComponent<Renderer>().material = foots;
        }
    }

    private void StartEvent()
    {
        Debug.Log("COUCOU");
        character.DOFade(1f, fadeInTime).SetEase(Ease.InOutSine);

        if (eventCount == 1)
        {
            object2.gameObject.SetActive(true);
            character.sprite = ugly ? uglyCharacter1 : image1;
        }
        else if (eventCount == 2)
        {
            object3.gameObject.SetActive(true);
            character.sprite = ugly ? uglyCharacter2 : image2;
        }
        else if (eventCount == 3)
        {
            object4.gameObject.SetActive(true);
            character.sprite = ugly ? uglyCharacter3 : image3;
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
