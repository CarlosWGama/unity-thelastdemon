using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class ScorePerson {

    public string name;
    public float time;
    public int level;

    public string Time { get { return Mathf.Floor(time / 60) + ":" + (time % 60).ToString("00"); } }

    public ScorePerson(string name, float time, int level) {
        this.name = name;
        this.time = time;
        this.level = level;
    }
}
