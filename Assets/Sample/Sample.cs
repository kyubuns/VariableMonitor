using UnityEngine;
using UnityEngine.UI;
using VariableMonitor;

public class Sample : MonoBehaviour
{
    [SerializeField] private Button variablePlusA;
    [SerializeField] private Button variableMinusA;
    [SerializeField] private Button variablePlusB;
    [SerializeField] private Button variableMinusB;
    [SerializeField] private Button variablePlusC;
    [SerializeField] private Button variableMinusC;

    public void Start()
    {
        Debug.Log("Start");

        var variableA = 0;
        var variableB = 0;
        var variableC = 0;
        VariableLogger.Log("VariableA", variableA);
        VariableLogger.Log("VariableB", variableB);
        VariableLogger.Log("VariableC", variableC);

        variablePlusA.onClick.AddListener(() =>
        {
            variableA++;
            VariableLogger.Log("VariableA", variableA);
        });

        variableMinusA.onClick.AddListener(() =>
        {
            variableA--;
            VariableLogger.Log("VariableA", variableA);
        });

        variablePlusB.onClick.AddListener(() =>
        {
            variableB++;
            VariableLogger.Log("VariableB", variableB);
        });

        variableMinusB.onClick.AddListener(() =>
        {
            variableB--;
            VariableLogger.Log("VariableB", variableB);
        });

        variablePlusC.onClick.AddListener(() =>
        {
            variableC++;
            VariableLogger.Log("VariableC", variableC);
        });

        variableMinusC.onClick.AddListener(() =>
        {
            variableC--;
            VariableLogger.Log("VariableC", variableC);
        });
    }
}
