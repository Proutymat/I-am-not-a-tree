using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int timeToWait = 7;
    [SerializeField] private GameObject endingObject;
    [SerializeField] private GameObject character;
    private int eventCount = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void StartEvent()
    {
        // On récupère le matériau
        var renderer = character.GetComponent<Renderer>();
        if (renderer != null)
        {
            // On met l'alpha à 0 au départ
            Color color = renderer.material.color;
            color.a = 0f;
            renderer.material.color = color;

            // On fait apparaître progressivement sur "timeToWait" secondes
            renderer.material.DOFade(1f, timeToWait).SetEase(Ease.InOutSine);
        }
    }

    private void PlayEnding()
    {
        endingObject.gameObject.SetActive(true);
    }
}
