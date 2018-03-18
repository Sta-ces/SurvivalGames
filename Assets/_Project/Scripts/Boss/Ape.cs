using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ape : Boss {

	[Header("Weapon")]
	public GameObject m_PrefabsBullet;
	[Range(1f,30f)]
	public float m_SpeedBullet = 5f;
	public Transform m_LocationSpawnBullet;
	[Range(1f,5f)]
	public float m_TimeDestroyBullet = 5f;

	public override void Attack(){
		Weapons.Instance.Shoot(m_PrefabsBullet, m_LocationSpawnBullet, m_SpeedBullet, m_TimeDestroyBullet);
	}
}
