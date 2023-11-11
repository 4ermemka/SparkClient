using System;
using Unity.Collections;

public class SPECIAL
{
    public int S {get; set;}
    public int P {get; set;}
    public int E {get; set;}
    public int C {get; set;}
    public int I {get; set;}
    public int A {get; set;}
    public int L {get; set;}

    public static SPECIAL operator + (SPECIAL a, SPECIAL b)
    {
        return new SPECIAL() 
        {
            S = a.S + b.S,
            P = a.P + b.P,
            E = a.E + b.E,
            C = a.C + b.C,
            I = a.I + b.I,
            A = a.A + b.A,
            L = a.L + b.L
        };
    }

    public static SPECIAL operator - (SPECIAL a, SPECIAL b)
    {
        return new SPECIAL() 
        {
            S = a.S - b.S,
            P = a.P - b.P,
            E = a.E - b.E,
            C = a.C - b.C,
            I = a.I - b.I,
            A = a.A - b.A,
            L = a.L - b.L
        };
    }

    public static bool operator == (SPECIAL a, SPECIAL b)
    {
        return
        a.S == b.S &&
        a.P == b.P &&
        a.E == b.E &&
        a.C == b.C &&
        a.I == b.I &&
        a.A == b.A &&
        a.L == b.L;
    }

    public static bool operator != (SPECIAL a, SPECIAL b)
    {
        return
        a.S != b.S ||
        a.P != b.P ||
        a.E != b.E ||
        a.C != b.C ||
        a.I != b.I ||
        a.A != b.A ||
        a.L != b.L;
    }
}