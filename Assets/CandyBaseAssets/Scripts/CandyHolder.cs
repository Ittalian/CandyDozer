using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHolder : MonoBehaviour
{
    const int DefaultCandyAmount = 30;
    const int RecoverySeconds = 10;

    int candy = DefaultCandyAmount;
    int counter;

    public void ConsumeCandy() {
        if(candy > 0)
            candy--;
    }

    public int GetCandyAmount() {
        return candy;
    }

    public void AddCandy(int amount) {
        candy += amount;
    }

    void OnGUI() {
        GUI.color = Color.black;
        string labal = "Candy : " + candy;

        if(counter > 0)
            labal = labal + " (" + counter + "s)";

        GUI.Label(new Rect(23, 30, 100, 30), labal);
    }

    void Update() {
        if(candy < DefaultCandyAmount && counter <= 0)
        {
            StartCoroutine(RecoveryCandy());
        }
    }

    IEnumerator RecoveryCandy() {
        counter = RecoverySeconds;

        while(counter > 0)
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }

        candy++;
    }
}
