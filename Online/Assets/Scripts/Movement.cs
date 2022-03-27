using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Movement : MonoBehaviourPunCallbacks, IPunObservable
{
    public Rigidbody2D rb2D;
    public float speed;
    Vector3 rakipPos;
    float delay = 8;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
            stream.SendNext(transform.position);
        else if (stream.IsReading)
            rakipPos = (Vector3)stream.ReceiveNext();
    }

    private void Update()
    {
        if (!photonView.IsMine)
            transform.position = Vector3.Lerp(transform.position, rakipPos, delay * Time.deltaTime);
        else if (photonView.IsMine)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;
    }
}
