using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDEV.PlatformGame
{
    public class Hammer : MonoBehaviour
    {
        public LayerMask enemyLayer;
        public float atkRadius;
        public Vector3 offset;
        [SerializeField]
        private Player m_player;

        public void Attack()
        {
            if (m_player == null) return;

            Collider2D col = Physics2D.OverlapCircle(transform.position + offset, atkRadius, enemyLayer);

            if (col)
            {
                Enemy enemy = col.gameObject.GetComponent<Enemy>();
                if (enemy)
                {
                    enemy.TakeDamage(m_player.stat.damage, m_player);
                }
            }
        }

        private void Update()
        {
            if(m_player == null) return;

            if(m_player.transform.localScale.x > 0)
            {
                if(offset.x < 0)
                {
                    offset = new Vector3(offset.x * -1, offset.y, offset.z);
                }
            }else if(m_player.transform.localScale.x < 0)
            {
                if (offset.x > 0)
                {
                    offset = new Vector3(offset.x * -1, offset.y, offset.z);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Helper.ChangAlpha(Color.yellow, 0.4f);
            Gizmos.DrawSphere(transform.position + offset, atkRadius);
        }
    }
}
