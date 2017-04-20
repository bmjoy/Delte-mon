﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymManager : MonoBehaviour {

	public GameObject trainers;	

	// Checks to see if all trainers have been defeated yet. If not, all become active.
	// This way player must always defeat (and redefeat if they fail) all trainers before getting to the gym leader.
	void Start () {
		bool gymDefeated = true;
		bool[] sceneTrainerData = GameManager.GameMan.curSceneData.trainers;
		for (int i = 0; i < sceneTrainerData.Length; i++) {
			// If a single trainer remains undefeated (including gym leader), gym is undefeated
			if (!sceneTrainerData [i]) {
				gymDefeated = false;
				break;
			}
		}
		// Reactivate all trainers if gym is undefeated
		if (!gymDefeated) {
			foreach (Transform child in trainers.transform) {
				child.GetComponent <NPCInteraction>().hasTriggered = false;
			}
		}
	}
}
