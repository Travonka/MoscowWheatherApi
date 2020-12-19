using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public enum CloudCoverege
    {
        SKC,
        NCD,
        CLR,
        NSC,
        FEW,
        SCT,
        BKN,
        OVC,
        VV,
        undefined
    }
    public enum Condition
    {
        SN,
        RA,
        DZ,
        SG,
        GR,
        FG,
        BR,
        FU,
        VA,
        HZ,
        SA,
        DU,
        SQ,
        SS,
        DS,
        TS,
        undefined
    }
    public enum Description
    {
        SH,
        ML,
        VC,
        BC,
        DR,
        BL,
        FZ,
        PR,
        RE,
        undefined
    }
    public enum Directions
    {   none,
        N,
        W,
        S,
        E,
        NW,
        NE,
        SE,
        SW
    }
    public enum Measurmnet
    {
        KT,
        MPS,
        KMH
    }
    public enum DistanceMeasurmnet
    { 
        Meters,
        Foots
    }
}
