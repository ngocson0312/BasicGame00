using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDEV.PlatformGame
{
    public class FireBullet : MonoBehaviour
    {
        public Player player;
        public Transform firePoint;
        public Bullet bulletPb;

        private float m_curSpeed;

        public void Fire()
        {
            if (!bulletPb || !player || !firePoint || GameManager.Ins.CurBullet <= 0) return;

            m_curSpeed = player.IsFacingLeft ? -bulletPb.speed : bulletPb.speed;
            var bulletClone = Instantiate(bulletPb, firePoint.position, Quaternion.identity);
            bulletClone.speed = m_curSpeed;
            bulletClone.owner = player;
            GameManager.Ins.ReduceBullet();

            AudioController.ins.PlaySound(AudioController.ins.fireBullet);
        }
    }
}
