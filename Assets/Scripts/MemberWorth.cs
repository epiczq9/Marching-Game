using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberWorth : MonoBehaviour
{
    public int worth;
    int worthBase;
    RadialController radialController;

    private void Start() {
        worthBase = worth;
    }

    public void ChangeWorth(int newWorth) {
        worth = newWorth;
    }
}
