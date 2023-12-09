using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Samples;
public class TestInteractable : MonoBehaviour
{
    public GameObject step1, step2, step3,step1a, step2a, step3a;

    GameObject[] gos;
    GameObject[] gosa;

    int currentIndex = 2;

    string currentFocus;

    // Start is called before the first frame update
    void Start()
    {
        gos = new GameObject[] { step1, step2, step3 };
        gosa = new GameObject[] { step1a, step2a, step3a };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentFocus != "Hand")
        {
            currentFocus = other.gameObject.tag;

            //GameObject Spawn() => Instantiate(gosa[currentIndex - 1]);
            gos[currentIndex - 1].SetActive(false);
            gosa[currentIndex - 1].SetActive(false);

            RespawnOnDropModified[] respawners = gosa[currentIndex - 1].GetComponentsInChildren<RespawnOnDropModified>();

            foreach(RespawnOnDropModified respawner in respawners)
            {
                respawner.Respawn();
            }

            currentIndex += 1;

            if (currentIndex == 4)
            {
                currentIndex = 1;
            }

            gos[currentIndex - 1].SetActive(true);
            gosa[currentIndex - 1].SetActive(true);
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Hand" && currentFocus == "Hand")
        {
            currentFocus = "";
        }


    }
}
