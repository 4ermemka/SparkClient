using System;

public class Buff : SPECIAL
{
    public int Duration;
    public void Decrease()
    {
        if (Duration > 0)
        {
            Duration--;
        }
    }
}
