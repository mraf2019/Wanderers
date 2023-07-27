using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
//using Photon.Pun;

public class PlayerListItem : Photon.MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text text;
    PhotonPlayer player;

    public void SetUp(PhotonPlayer _player){
        player = _player;
        text.text = _player.NickName;
    }

    public void OnPlayerLeftRoom(PhotonPlayer otherPlayer){
        if (player == otherPlayer){
            Destroy(gameObject);
        }
    }

    public void OnLeftRoom(){
        Destroy(gameObject);
    }
}
