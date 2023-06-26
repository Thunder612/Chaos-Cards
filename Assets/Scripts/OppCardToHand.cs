using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppCardToHand : MonoBehaviour
{
    public GameObject oppHand;
    public GameObject oppHandCard;


    // Start is called before the first frame update
    void Start()
    {

        oppHand = GameObject.Find("OppZone");
        oppHandCard.transform.SetParent(oppHand.transform);
        oppHandCard.transform.localScale = Vector3.one;
        oppHandCard.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        oppHandCard.transform.eulerAngles = new Vector3(25, 0, 0);
        oppHand.GetComponent<OppZone>().drawCard(this);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
