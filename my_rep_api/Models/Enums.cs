using System.ComponentModel;

namespace myrep.Models
{
    public enum PoliticalParties
    {
        [Description("Chama Cha Mapinduzi")]
        CCM,
        [Description("Chama cha Demokrasia na Maendeleo")]
        CHADEMA,
        [Description("Civic United Front")]
        CUF,
        [Description("Alliance for Change and Transparency")]
        ACT,
        [Description("Tanzania Labour Party")]
        TLP,
        [Description("National Convention for Construction and Reform")]
        NCCR        
    }

    public enum MemberTypes
    {
        SpecialSeats,
        ConstituentMember,
        Nominated
    }
}