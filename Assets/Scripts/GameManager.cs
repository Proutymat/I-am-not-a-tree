using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int timeToWait = 7;
    [SerializeField] private GameObject endingObject;
    [SerializeField] private Image character;
    private int eventCount = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // On le rend totalement transparent au départ
        var color = character.color;
        color.a = 0f;
        character.color = color;

        
        StartEvent();
    }

    private void StartEvent()
    {
        Debug.Log("COUCOU");
        // On fait apparaître progressivement sur "timeToWait" secondes
        character.DOFade(1f, timeToWait).SetEase(Ease.InOutSine);
    }

    private void PlayEnding()
    {
        endingObject.gameObject.SetActive(true);
    }
}
