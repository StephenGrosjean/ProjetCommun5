using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject livingRoom, garden, hall, kitchen;
    [SerializeField] private bool livingRoom_Active, garden_Active, hall_Active, kitchen_Active;

    private string currentRoom;
    public string CurrentRoom {
        get { return currentRoom; }
        set { currentRoom = value; }
    }

    public void ChangeRoom(string room) {
          switch (room) {
            case "LivingRoom":
                livingRoom_Active = true;
                garden_Active = false;
                hall_Active = false;
                kitchen_Active = false;
                break;

            case "Garden":
                livingRoom_Active = false;
                garden_Active = true;
                hall_Active = false;
                kitchen_Active = false;
                break;

            case "Hall":
                livingRoom_Active = false;
                garden_Active = false;
                hall_Active = true;
                kitchen_Active = false;
                break;

            case "Kitchen":
                livingRoom_Active = false;
                garden_Active = false;
                hall_Active = false;
                kitchen_Active = true;
                break;
        }

        SwitchRooms();
    }


    void SwitchRooms() {
        if (livingRoom_Active) {
            livingRoom.SetActive(true);
            garden.SetActive(false);
            hall.SetActive(false);
            kitchen.SetActive(false);
        }

        if (garden_Active) {
            livingRoom.SetActive(false);
            garden.SetActive(true);
            hall.SetActive(false);
            kitchen.SetActive(false);
        }

        if (hall_Active) {
            livingRoom.SetActive(false);
            garden.SetActive(false);
            hall.SetActive(true);
            kitchen.SetActive(false);
        }

        if (kitchen_Active) {
            livingRoom.SetActive(false);
            garden.SetActive(false);
            hall.SetActive(false);
            kitchen.SetActive(true);
        }
    }

}
