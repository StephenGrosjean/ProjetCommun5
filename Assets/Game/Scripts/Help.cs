using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Help : MonoBehaviour
{
    [SerializeField] private string kitchen, garden, hall, livingRoom;
    [SerializeField] private string table, stove, sofa, shelf, tv, library;
    [SerializeField] private TextMeshProUGUI textNecklace, textWatch, textJewlery;

    public enum localization { Kitchen, Garden, Hall, LivingRoom };
    public enum Place { Table, Stove, Sofa, Shelf, TV, Library };
    public enum Item { Necklace, Watch, Jewlery};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setText(Item item, localization loc, Place place) {
        string textLoc = "", textPlace = "";
        Debug.Log(item + " " + loc + " " + place);

        switch (loc) {
            case localization.Kitchen:
                textLoc = kitchen;
                break;
            case localization.Garden:
                textLoc = garden;
                break;
            case localization.Hall:
                textLoc = hall;
                break;
            case localization.LivingRoom:
                textLoc = livingRoom;
                break;
        }

        switch (place) {
            case Place.Table:
                textPlace = table;
                break;
            case Place.Stove:
                textPlace = stove;
                break;
            case Place.Sofa:
                textPlace = sofa;
                break;
            case Place.Shelf:
                textPlace = shelf;
                break;
            case Place.TV:
                textPlace = tv;
                break;
            case Place.Library:
                textPlace = library;
                break;
        }

        if (item == Item.Necklace) {
            textNecklace.text = "Necklace \n" + textLoc + "\n" + textPlace;
        }
        if(item == Item.Watch) {
            textWatch.text = "Watch \n" + textLoc + "\n" + textPlace;
        }
        if(item == Item.Jewlery) {
            textJewlery.text = "Jewlery \n" + textLoc + "\n" + textPlace;
        }
    }

}
