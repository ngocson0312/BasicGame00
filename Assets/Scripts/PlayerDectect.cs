using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDEV.PlatformGame
{
    public class PlayerDectect : MonoBehaviour
    {
        public bool disable;
        public DetectMethod dectectMethod;
        public LayerMask targetLayer;
        public float detectDist;

        private Player m_target;
        private Vector2 m_dirToTarget;
        private bool m_isDetected;

        public Player Target { get => m_target;}
        public Vector2 DirToTarget { get => m_dirToTarget;}
        public bool IsDetected { get => m_isDetected;}

        private void Start()
        {
            m_target = GameManager.Ins.player;
        }

        private void FixedUpdate()
        {
            if (!m_target || disable) return;

            if(dectectMethod == DetectMethod.RayCast)
            {
                m_dirToTarget = m_target.transform.position - transform.position;
                m_dirToTarget.Normalize();

                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(m_dirToTarget.x, 0), detectDist, targetLayer);

                m_isDetected = hit.collider != null;

            }else if(dectectMethod == DetectMethod.CircleOverlap)
            {
                Collider2D col = Physics2D.OverlapCircle(transform.position, detectDist, targetLayer);
                m_isDetected = col != null;
            }

            if (m_isDetected)
            {
                Debug.Log("Player was detected!.");
            }
            else
            {
                Debug.Log("Player not detected!.");
            }
        }

        private void OnDrawGizmos()
        {
            if(dectectMethod == DetectMethod.RayCast)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position,
                    new Vector3(
                        transform.position.x + detectDist,
                        transform.position.y, transform.position.z
                    ));
            }else if(dectectMethod == DetectMethod.CircleOverlap)
            {
                Gizmos.color = Helper.ChangAlpha(Color.green, 0.2f);
                Gizmos.DrawSphere(transform.position, detectDist);
            }
        }
    }
}
