using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
public class WriteDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDialogue;
    public string[] lines;
    public string[] reactions;
    public float textSpeed;
    private int linesToRead;
    private int index = 0;
    private int reactionIndex;
    private bool isWritting = false;
    private bool isReacting = false;
    private bool firstCall = false;
    private Dictionary<string, int> objectIndex = new Dictionary<string, int>();
    void Start()
    {
        textDialogue.text = string.Empty;
        objectIndex.Add("Bug", 1);
        objectIndex.Add("Leaf", 2);
        objectIndex.Add("Annoucement", 3);
        objectIndex.Add("Cake", 4);
        objectIndex.Add("Tissue", 5);
        objectIndex.Add("Beer", 6);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (firstCall)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!isReacting)
                {
                    if (textDialogue.text == lines[index])
                    {
                        NextLine();
                        isWritting = true;
                    }
                    else
                    {
                        StopAllCoroutines();
                        textDialogue.text = lines[index];
                        isWritting = false;
                    }
                }
                else
                {
                    if (textDialogue.text == reactions[reactionIndex])
                    {
                        isReacting = false;
                        isWritting = true;
                        NextLine();
                    }
                    else
                    {
                        StopAllCoroutines();
                        textDialogue.text = reactions[reactionIndex];
                        isWritting = false;
                    }
                }
            }
        }
        if (index > 8)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        isWritting = true;
        textDialogue.text = string.Empty;
        foreach (char c in lines[index].ToCharArray())
        {
            textDialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    IEnumerator TypeLineReaction()
    {
        isWritting = true;
        textDialogue.text = string.Empty;
        foreach (char c in reactions[reactionIndex].ToCharArray())
        {
            textDialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < linesToRead - 1)
        {
            index++;
            textDialogue.text = string.Empty;
            StartCoroutine(TypeLine());
            isWritting = true;
        }
        else
        {
            isWritting = false;
            gameObject.SetActive(false);
        }
    }
    public void CallNextLines(int numberOfLines)
    {
        firstCall = true;
        linesToRead += numberOfLines ;
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());
        isWritting = true;
    }

    public void WriteReaction(string Object)
    {
        gameObject.SetActive(true);
        if (isWritting == true)
        {
            StopAllCoroutines();
            if (!isReacting)
            {
                index--;
            }
        }
        isReacting = true;
        reactionIndex = objectIndex[Object];
        if (Random.Range(0, 2) < 1)
        {
            reactionIndex = reactionIndex + 6;
        }

        textDialogue.text = string.Empty;
        isWritting = true;
        StartCoroutine(TypeLineReaction());
    }
}