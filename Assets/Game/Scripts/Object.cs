using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[ExecuteInEditMode]
public class Object : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool asObject;
    public bool AsObject {
        get { return asObject; }
    }

    [SerializeField] private GameObject objectToHide;
    [SerializeField] private Help.localization localization;
    [SerializeField] private Help.Place place;
    private Help.Item item;
   [SerializeField] private Help helpScript;


    private void Start() {
        Setup();
        helpScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<Help>();
    }

    public void SetObject(GameObject obj) {
        objectToHide = obj;
        objectToHide.transform.position = spawnPoint.position;
        asObject = true;
        Debug.Log(gameObject.name + " as " + objectToHide.name);

        item = obj.GetComponent<Item>().ItemID;

        helpScript.setText(item, localization, place);

    }

    public void DiscoverObject() {
        asObject = false;
        objectToHide.GetComponentInChildren<Animator>().SetBool("isFound", true);
        Destroy(objectToHide, 3);
    }


   
    void Setup() {
        if (transform.childCount == 0) {
            gameObject.tag = "Object";
            GameObject obj = new GameObject();
            obj.name = "SpawnPoint";
            obj.transform.parent = transform;
            spawnPoint = obj.transform;
        }
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
}
