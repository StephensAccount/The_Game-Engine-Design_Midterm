using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class spikedEditorEvents
{
    public abstract Color SpikeEditorColor();
}

public class YellowMat : spikedEditorEvents
{
    public override Color SpikeEditorColor()
    {
        return Color.yellow;
    }
}

public class GreenMat : spikedEditorEvents
{
    public override Color SpikeEditorColor()
    {
        return Color.green;
    }
}