using System.Collections.Generic;
using System;

[Serializable]
public class Record
{
    public string _id; 
    public int rank;
    public string name; 
    public string createdAt; 
    public List<Score> scores; 
    public int bestScore; 
    public int attempt; 
}