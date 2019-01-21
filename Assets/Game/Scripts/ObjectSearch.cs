using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSearch : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private GameManager GM;

    private bool isActived;
    private GameObject currentObject;
    private bool canSearch = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActived) {
            if (Input.GetKeyDown(KeyCode.F) && canSearch) {
                canSearch = false;

                if (currentObject.GetComponent<Object>().AsObject) {
                    currentObject.GetComponent<Object>().DiscoverObject();
                    GM.AddObjectFound();
                }
                else {
                    GM.AddMissed();
                }

                StartCoroutine("Delay");
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Object") {
            currentObject = collision.gameObject;
            popup.SetActive(true);
            isActived = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Object") { 
            currentObject = null;
            popup.SetActive(false);
            isActived = false;
        }
    }

   
    IEnumerator Delay() {
        yield return new WaitForSeconds(1);
        canSearch = true;
    }



}
