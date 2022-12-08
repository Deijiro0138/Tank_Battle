
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
public class photon : Photon.MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _count;
    [SerializeField] private GameObject _room;
    [SerializeField] private GameObject _left;
    [SerializeField] private Text _currentStateText;

    // Use this for initialization
    // Update is called once per frame
    void Start()
    {
        PhotonNetwork.offlineMode = false;
        PhotonNetwork.ConnectUsingSettings("v0.1");
        _left.SetActive(false);
        _left.GetComponent<Button>().onClick.AddListener(LeftRoom);
        GetComponent<Button>().onClick.AddListener(OnTapped);
    }
    void Update()
    {
        var room = PhotonNetwork.GetRoomList().ToList().Find(r=>r.name==_name.text);
        if (room != null)
        {
            _count.text = room.playerCount + "/" + room.maxPlayers;
        }
        else
        {
            _count.text = 0 + "/" + 4;
        
        }
    }
    void OnJoinedLobby()
    {
        Debug.Log("入室しました。");
        _currentStateText.text = "Lobby";
    }
   
    void OnJoinedRoom()
    {
        _currentStateText.text = "" + PhotonNetwork.room.name;
        _room.SetActive(false);
        _left.SetActive(true);
    }
    void OnLeftRoom() {
        _currentStateText.text = "Lobby:" + PhotonNetwork.lobby.Name;
        _room.SetActive(true);
        _left.SetActive(false);
    }
    void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        Debug.Log("ID:"+otherPlayer.ID+"left room");
        GetComponent<InRoomChat>().messages.Add("Player"+otherPlayer.ID+"さんが退室しました");
    }
    void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        Debug.Log("Joined otherPlayer");
        GetComponent<InRoomChat>().messages.Add("Player"+newPlayer.ID+"さんが入室しました");
    }
    public void LeftRoom()
    {
        PhotonNetwork.LeaveRoom();
        GetComponent<InRoomChat>().messages.Clear();
    }
    public void OnTapped()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.isOpen = true;
        roomOptions.isVisible = true;
        roomOptions.maxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(_name.text,roomOptions,new TypedLobby());
    }
    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}
