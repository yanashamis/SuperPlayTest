using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class uiHolder : MonoBehaviour
{
    public coinManager CoinManager;
    private RawImage barRawImage;
    private RectTransform barMaskrectTransform;
    public float speed;
    public const float maxWidthOfBar = 600;
    public GameObject edge;

    private float random()
    {
        float a = Random.Range(10f, 90f);
        return a;
    }

    public void ChangeState(float percents)
    {
        if ((percents > 100) || (percents < 0))
            return;
        StartCoroutine(ChangeStateCor(percents));
    }

    public void RandomButton1()
    {
        float randomPercent = random();
        //Debug.Log("random percent: " + randomPercent);
        ChangeState(randomPercent);
    }

    IEnumerator ChangeStateCor(float percents)
    {
        yield return new WaitForEndOfFrame();
         if(Mathf.Abs(barMaskrectTransform.sizeDelta.x - maxWidthOfBar * percents / 100) > speed)
        {
            if(barMaskrectTransform.sizeDelta.x < maxWidthOfBar * percents / 100)
               barMaskrectTransform.sizeDelta += new Vector2(speed, 0);
            else
               barMaskrectTransform.sizeDelta -= new Vector2(speed, 0);
               StartCoroutine(ChangeStateCor(percents));
        }
        
        else if (percents == 100)
        {
            CoinManager.lastButton();
        }
    }


    private Image barImage;
    private void Awake()
    {

        barMaskrectTransform = transform.Find("barMask").GetComponent<RectTransform>();
        barRawImage = transform.Find("barMask").Find("bar").GetComponent<RawImage>();   
    }



    private void Update()
    {
        Rect uvRect = barRawImage.uvRect;
        uvRect.x -= .2f * Time.deltaTime;
        barRawImage.uvRect = uvRect;

    }

}
