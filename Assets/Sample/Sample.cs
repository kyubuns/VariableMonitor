using UniRx;
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

        var variableA = new ReactiveProperty<int>(2);
        var variableB = new ReactiveProperty<int>(4);
        var variableC = new ReactiveProperty<int>(6);
        VariableLogger.Register("VariableA", variableA);
        VariableLogger.Register("VariableB", variableB);
        VariableLogger.Register("VariableC", variableC);

        variablePlusA.onClick.AddListener(() =>
        {
            variableA.Value++;
        });

        variableMinusA.onClick.AddListener(() =>
        {
            variableA.Value--;
        });

        variablePlusB.onClick.AddListener(() =>
        {
            variableB.Value++;
        });

        variableMinusB.onClick.AddListener(() =>
        {
            variableB.Value--;
        });

        variablePlusC.onClick.AddListener(() =>
        {
            variableC.Value++;
        });

        variableMinusC.onClick.AddListener(() =>
        {
            variableC.Value--;
        });
    }
}
