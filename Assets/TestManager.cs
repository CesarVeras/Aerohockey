using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System;
using UnityEngine;

public class TestManager {

    public TestManager()
    {
        //BeginTests();
    }

    float tempoInicio;
    List<string[]> tmpErrors;
    Hashtable errors;


    protected void BeginTests()
    {
        float tempoInicio = Time.time;
        Regex regex = new Regex(@"^Test.*$");
        errors = new Hashtable();
        List<int> numErrors = new List<int>();
        int totalErrors = 0;
        foreach(MethodInfo method in GetType().GetMethods()) {
            if(regex.Matches(method.Name).Count == 1) {
                tmpErrors = new List<string[]>();
                method.Invoke(this, null);
                errors.Add(method.Name,tmpErrors);
                numErrors.Add(tmpErrors.Count);
                totalErrors += tmpErrors.Count;
            }
        }
        float tempoFinal = Time.time;
        string str = "";
        if (totalErrors > 0)
        {
            foreach(string name in errors.Keys)
            {
                str += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
                var meth = (List<string[]>) errors[name];
                str += name + ", " + meth.Count + " errors\n";
                foreach (string[] strs in meth)
                {
                    str += "------------------------------\n";
                    str += strs[1] + '\n';
                    str += strs[0] + '\n';
                }
            }
        }
        str += "==============================\n";
        str += "Executed " + errors.Count + " tests in " + (tempoFinal - tempoInicio) + "s\n";
        str += "with " + totalErrors + " errors\n";
        Debug.Log(str);
    }

    public void AssertEquals(object saida, object esperado)
    {
        string trace = StackTraceUtility.ExtractStackTrace();
        if (!saida.Equals(esperado))
        {
            tmpErrors.Add(String(trace, saida, esperado));
        }
    }

    public void AssertNotEquals(object saida, object esperado)
    {
        string trace = StackTraceUtility.ExtractStackTrace();
        if (saida == esperado)
        {
            tmpErrors.Add(String(trace, saida, esperado, true));
        }
    }

    public void AssertTrue(bool saida)
    {
        string trace = StackTraceUtility.ExtractStackTrace();
        if (!saida)
        {
            tmpErrors.Add(String(trace, saida, true));
        }
    }

    public void AssertFalse(bool saida)
    {
        string trace = StackTraceUtility.ExtractStackTrace();
        if (saida)
        {
            tmpErrors.Add(String(trace, saida, false));
        }
    }

    public void AssertNull(object saida)
    {
        string trace = StackTraceUtility.ExtractStackTrace();
        if (saida != null)
        {
            tmpErrors.Add(String(trace, saida, null, true));
        }
    }

    public void AssertNotNull(object saida)
    {
        string trace = StackTraceUtility.ExtractStackTrace();
        if (saida == null)
        {
            tmpErrors.Add(String(trace, saida, null));
        }
    }

    private string[] String(string trace, object obj1, object obj2, bool equals = false)
    {
        return new string[] { trace, obj1.ToString() + (equals ? '=' : '!') + '=' + obj2.ToString() };
    }
}
