using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowManager : MonoBehaviour
{
    [SerializeField] private string nonPlayerTag = "Untagged";
    [SerializeField] private List<GameObject> humans;
    [SerializeField] private int currentHost = 0;
    [SerializeField] private VoidEventChannelSO playerJumped;
    
    void Start()
    {
        for (int i = 0; i < humans.Count; i++)
        {
            if (humans[i].CompareTag("Player"))
            {
                currentHost = i;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            humans[currentHost].tag = nonPlayerTag;
            
            if (currentHost == humans.Count - 1)
            {
                currentHost = 0;
            }
            else
            {
                currentHost++;
            }

            humans[currentHost].tag = "Player";
            playerJumped.RaiseEvent();
        }
    }
}
