using UnityEngine;
using System;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]

    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }          
        private GameObject player;
        public static float Sight_Width, Sight_Range;
        public bool Alarm;

        private void Start()
        {
            agent = GetComponentInChildren<NavMeshAgent>();
            agent.enabled = false;
            agent.updateRotation = false;
            agent.updatePosition = true;
            player = GameObject.Find("Player");

            Sight_Range = 0;
            Sight_Width = 90;

            GetComponent<AudioSource>().Play(22000);
            Alarm = false;
        }


        private void Update()
        {
            if (player != null)
                agent.SetDestination(player.transform.position);

            if (CanSeePlayer() == true)
            {
                agent.enabled = true;
                print("he saw ya");
            }
            if(Alarm)
            {
                agent.enabled = true;
            }
        }

        bool CanSeePlayer()
        {
            Vector3 startVec = transform.position;
            Vector3 startVecFwd = transform.forward;

            RaycastHit hit;
            Vector3 rayDirection = player.transform.position - startVec;
            Debug.DrawRay(transform.position, rayDirection);

            if ((Vector3.Angle(rayDirection, startVecFwd)) < 360 && (Vector3.Distance(startVec, player.transform.position) <= 0))
            {
                return true;
            }

            if ((Vector3.Angle(rayDirection, startVecFwd)) < Sight_Width && (Vector3.Distance(startVec, player.transform.position) <= Sight_Range))
                if (Physics.Raycast(startVec, rayDirection, out hit, 100f))
                {
                    if (hit.transform.tag == "Player")
                        return true;
                    else
                        return false;
                }
            return false;
        }     
    }
}
