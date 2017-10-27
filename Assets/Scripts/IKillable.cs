using UnityEngine;

public interface IKillable{

	void TakeHit (float damage, RaycastHit hit);
}