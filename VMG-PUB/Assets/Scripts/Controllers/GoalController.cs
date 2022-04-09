using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GoalController : MonoBehaviourPunCallbacks
{
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("@Player") == null) return;
    }

    // Update is called once per frame
    void Update()
    {
        go = GameObject.Find("@Player");
        if (go == null) return;

        // if (go.GetComponent<PhotonView>().IsMine)
        // {
        if (go.GetComponent<PlayerController>()._goalCheck)
        {
            Debug.Log("골인");
            go.GetComponent<PlayerController>()._mode = PlayerController.modeState.Square;
            go.GetComponent<PlayerController>()._goalCheck = false;
            Managers.Network.LeaveRoom();
            Managers.Scene.LoadScene(Define.Scene.Square);
            Managers.Network.OnLogin();
        }
        // }
    }

    private void OnTriggerEnter(Collider other) {
        // if (go.GetComponent<PhotonView>().IsMine)
        {
            go.GetComponent<PlayerController>()._goalCheck = true;
        }
    }
}