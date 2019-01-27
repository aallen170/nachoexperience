using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThoughtBubble : MonoBehaviour
{

    #region Variables
    #region Text Vars
    Text textComponent;

    public string mainText = "This is a test to see if the script actually works";

    int strIndex = 0;
    #endregion Text Vars

    #region Time Vars
    float currentTime = Mathf.Epsilon, maxTime = 1f;
    #endregion Time Vars

    #region Adjustable Vars
    [Range(1, 200)]
    [SerializeField]
    float speechSpeed = 60f, bubbleBufferX = 50f, bubbleBufferY = 30f;
    #endregion Adjustable Vars

    #region Rectangle Transforms
    RectTransform textRectTrans, bubbleRecTrans, dotsRectTrans;
    #endregion Rectangle Tranforms
    #endregion Varables

    PlayerInteractive pInteractive;

    Player pScript;

    // Use this for initialization
    void Start()
    {
        FindComponents();
        ClearText();
    }

    // Update is called once per frame
    void Update()
    {
        BuildTextBox();
        ResizeThoughtBubble();
        //PositionThoguhtDots();

        print(pInteractive.GetInteractableQuip(pScript.GetInteractable(), "CameraClickArea"));

        if (pScript.GetInteractable() != null)
        {
            ClearText();
            mainText = pInteractive.GetInteractableQuip(pScript.GetInteractable(), "CameraClickArea");
        }

        //if (strIndex >= mainText.Length)
        //{
        //    ClearText();
        //}
    }

    private void FindComponents()
    {
        textComponent = transform.Find("Text").GetComponent<Text>();
        textRectTrans = transform.Find("Text").GetComponent<RectTransform>();
        bubbleRecTrans = transform.Find("ThoughtBubble").GetComponent<RectTransform>();
        dotsRectTrans = transform.Find("ThoughtDots").GetComponent<RectTransform>();
        pInteractive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteractive>();
        pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        textComponent.text = "";
    }

    private void BuildTextBox()
    {
        currentTime += Time.deltaTime * speechSpeed;

        if (strIndex < mainText.Length && currentTime >= maxTime)
        {
            textComponent.text += mainText[strIndex];
            strIndex++;

            currentTime = Mathf.Epsilon;
        }
    }

    private void ResizeThoughtBubble()
    {
        bubbleRecTrans.sizeDelta = textRectTrans.sizeDelta + new Vector2(bubbleBufferX, bubbleBufferY);
    }

    private void PositionThoguhtDots()
    {
        dotsRectTrans.localPosition = new Vector3(
            -bubbleRecTrans.sizeDelta.x / 2 + dotsRectTrans.sizeDelta.x / 2,
            -bubbleRecTrans.sizeDelta.y / 2 - dotsRectTrans.sizeDelta.y / 2,
            Mathf.Epsilon
        );
    }

    private void ClearText()
    {
        textComponent.text = "";
        strIndex = 0;
    }
}
