using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderStPlayer : SliderSt {

	// Use this for initialization
	protected override void Start () {
        currentSt = totalSt = 10;
        base.Start();
	}

    // Update is called once per frame
    protected override void Update () {
        base.Update();
	}
}
