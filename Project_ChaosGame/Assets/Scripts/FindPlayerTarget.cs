using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerTarget : MonoBehaviour
{
    public Cinemachine.CinemachineTargetGroup group;
    [SerializeField] float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateTargetGroup()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        group.m_Targets = new Cinemachine.CinemachineTargetGroup.Target[GameObject.FindGameObjectsWithTag("Player").Length];
        if(group.m_Targets.Length <= 2)
        {
            for(int i = 0; i< players.Length; i++ )
            {
                group.m_Targets[i].target = players[i].transform;
                group.m_Targets[i].radius = radius;
            }
        }
    }
}
