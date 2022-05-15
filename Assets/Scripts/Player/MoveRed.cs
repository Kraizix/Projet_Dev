using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRed : MonoBehaviour
{
     private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = transform.parent.GetComponent<Player>();
    }
    
    private void OnTriggerStay2D(Collider2D col) {
        if ((col.gameObject.tag == "Tile" || col.gameObject.tag == "Portal"  || col.gameObject.tag == "Create") && _player.index == 1)
            {
                float dist = (this.transform.position - col.transform.position).magnitude;
                if (dist <= 0.40f)
                {
                    _player.CollisionCubename = col.gameObject.name;
                    _player.isMoveBallCollNew = true;
                    _player.dist = dist;
                }
            }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (_player.index == 1)
        {
            if(_player.game){
                if(int.Parse(col.gameObject.name.Split()[1]) == int.Parse(_player.currentCol.Split()[1]) + 1){
                    _player.isMoveBallCollNew = false;
                }
            } else {
                _player.isMoveBallCollNew = false;
            }
        }
    }
}
