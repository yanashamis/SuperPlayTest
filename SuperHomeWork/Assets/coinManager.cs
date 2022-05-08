using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class coinManager : MonoBehaviour
{
    //------------------------------test animated coin
    [SerializeField] GameObject animatedCoinPrefab;
    [SerializeField] Transform target;
    public Transform collectedCoinPosition;


    [Space]
    [Header("availebal coins")]
    [SerializeField] int maxCoins;
    Queue<GameObject> coinsqueue = new Queue<GameObject>();

    [Space]
    [Header("animation settings")]
    [SerializeField] [Range(0.3f, 0.6f)] float minAnimDuraction;
    [SerializeField] [Range(0.9f, 1.5f)] float maxAnimDuraction;

    Vector3 targetPosition;

    [SerializeField] Ease easeType;
    [SerializeField] float spread;

    private void Awake()
    {
        targetPosition = target.position;
        prepareCoins();
   
    }
    //-----------------------test1
    public void lastButton()
    {
        while (coinsqueue.Count > 0) { 
            GameObject coin = coinsqueue.Dequeue();
        coin.SetActive(true);

        coin.transform.position = collectedCoinPosition.position; //+ new Vector3(Random.Range(-spread, spread), 0f, 0f);
        float duration = Random.Range(minAnimDuraction, maxAnimDuraction);

        coin.transform.DOMove(targetPosition, duration)
                .SetEase(easeType)
                .OnComplete(() =>
                {
                    coin.SetActive(false);
                    coinsqueue.Enqueue(coin);
                });
        }
    }



    void prepareCoins()
    {

        GameObject coin;
        for (int i = 0; i < maxCoins; i++)
        {

            coin = Instantiate(animatedCoinPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinsqueue.Enqueue(coin);
        }


    }

}
