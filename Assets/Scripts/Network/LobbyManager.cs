using Photon.Pun;
using TMPro;
using UnityEngine;
using RoomOptions = Photon.Realtime.RoomOptions;

namespace Game.Network
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField _createInput;
        [SerializeField] private TMP_InputField _joinInput;

        public void CreateRoom()
        {
            
            
            var roomOptions = new RoomOptions
            {
                MaxPlayers = 4
            };
            PhotonNetwork.CreateRoom(_createInput.text, roomOptions);
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(_joinInput.text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }
}
