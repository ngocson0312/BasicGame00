using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDEV.PlatformGame
{
    public class ObstacleChecker : MonoBehaviour
    {
        public LayerMask groundLayer;
        public LayerMask waterLayer;
        public LayerMask ladderLayer;
        public float deepWaterChkDist;
        public float checkingRadius;
        public Vector3 offset;
        public Vector3 deepWaterOffset;
        private bool m_isOnGround;
        private bool m_isOnWater;
        private bool m_isOnLadder;
        private bool m_isOnDeepWater;

        public bool IsOnGround { get => m_isOnGround;}
        public bool IsOnWater { get => m_isOnWater;}
        public bool IsOnLadder { get => m_isOnLadder;}
        public bool IsOnDeepWater { get => m_isOnDeepWater;}

        private void FixedUpdate()
        {
            m_isOnGround = OverlapChecking(groundLayer);
            m_isOnWater = OverlapChecking(waterLayer); 
            m_isOnLadder = OverlapChecking(ladderLayer);

            RaycastHit2D waterHit = Physics2D.Raycast(transform.position + deepWaterOffset, 
                Vector2.up, deepWaterChkDist, waterLayer);

            m_isOnDeepWater = waterHit;

            //Debug.Log($"Ground : {m_isOnGround} _ Water: {m_isOnWater} _ Ladder : {m_isOnLadder}");
        }

        private bool OverlapChecking(LayerMask layerToCheck)
        {
            Collider2D col = Physics2D.OverlapCircle(
                transform.position + offset,
                checkingRadius, layerToCheck
                );

            return col != null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Helper.ChangAlpha(Color.red, 0.4f);
            Gizmos.DrawSphere(transform.position + offset, checkingRadius);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position + deepWaterOffset,
                new Vector3(
                    transform.position.x + deepWaterOffset.x,
                    transform.position.y + deepWaterOffset.y + deepWaterChkDist,
                    transform.position.z
                ));
        }
    }
}
