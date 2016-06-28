using System.Collections.Generic;
using System;

[Serializable]
public class Rank {

    public int sizeRank = 5;
    public List<ScorePerson> scores = new List<ScorePerson>();

    public void AddScore(ScorePerson score) {

        for (int i = 0; i < sizeRank; i++) {

            //Adiciona se não existir
            if (i == (scores.Count)) { 
                scores.Add(score);
                break;
            }

            if (score.level > scores[i].level) { //Tem um level maior
                scores.Insert(i, score);
                break;
            } else if (score.level == scores[i].level && score.time < scores[i].time) {  //Está no mesmo level mas com tempo menor
                scores.Insert(i, score);
                break;
            }
        }

        if (scores.Count > sizeRank)
            scores.RemoveAt(scores.Count - 1);
    }
}
