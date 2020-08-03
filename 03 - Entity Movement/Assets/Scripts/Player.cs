using Photon.Pun;
using Unit.Movement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] string unitName;
    [SerializeField] Transform spawn;
    [SerializeField] Transform target;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            var newUnit = PhotonNetwork.Instantiate(unitName, spawn.position, spawn.rotation);
            newUnit.GetComponent<MovingUnit>().SetTarget(target, MovingType.Continues);
        }
    }
}
