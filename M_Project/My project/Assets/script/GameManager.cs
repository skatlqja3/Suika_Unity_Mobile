using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dongle lastDongle;
    public GameObject donglePrefab;
    public Transform dongleGroup;
    // Start is called before the first frame update
    void Start()
    {
        NextDongle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Dongle GetDongle()
    {
        GameObject instant = Instantiate(donglePrefab, dongleGroup);
        Dongle instantDongle = instant.GetComponent<Dongle>();
        return instantDongle;
    }
    void NextDongle()
    {
        Dongle newDongle = GetDongle();
        lastDongle = newDongle;
        lastDongle.level = UnityEngine.Random.Range(0, 3);
        lastDongle.gameObject.SetActive(true);

        StartCoroutine(waitNext());
    }
    IEnumerator waitNext()
    {
        while (lastDongle != null)
        {
            yield return null;
        }
        yield return new WaitForSeconds(2.5f);
        NextDongle();
    }

    public void TouchDown()
    {
        if(lastDongle == null)
            return;
        lastDongle.Drag();
    }
    public void TouchUp()
    {
        if (lastDongle == null)
            return;
        lastDongle.Drop();
        lastDongle = null;
    }
}
