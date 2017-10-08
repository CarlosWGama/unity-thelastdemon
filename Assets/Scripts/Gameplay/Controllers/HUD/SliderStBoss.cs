using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderStBoss : SliderSt {

	
    // Use this for initialization
	protected override void Start () {
        currentSt = totalSt = 20;
        base.Start();
	}
}
