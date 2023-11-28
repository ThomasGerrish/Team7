using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBase : MonoBehaviour
{
    /*
     * All edited in the inspector, the list will represent the pattern of enemies spawning going from left to right, up to a count of 9 ALWAYS
     * The enemies are indexed by : 
     * 0 - Shield
     * 1 - Standard
     * 2 - Heavy
     * 3 - Light
     * 4 - Explosive
     * This class simply serves as a reference and should be structured by for example 0,0,0,1,1,1,0,0,0
     * This will create a layer of standard enemies surrounded by blank shields.
     * 
     */
    public List<int> pattern;
}
