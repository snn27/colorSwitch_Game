using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Player scripPlayer;
    public Transform player;

    private void Update()
    {
        if(player.position.y > transform.position.y) //kamere playeri takibi
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
        if((player.position.y+10f) < transform.position.y) //kameraadan aşşagı doğru kaybolursa oyunu tekrar başlatsın
        {
            scripPlayer.again();
        }
    }

}
