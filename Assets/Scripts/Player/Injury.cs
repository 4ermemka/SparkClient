public enum BodyPart
{
    Head = 0,
    Torso = 1,
    LeftArm = 2,
    RightArm = 3,
    LeftLeg = 4,
    RightLeg = 5
}

public class Injury : Buff
{
    public BodyPart BodyPart;
}
