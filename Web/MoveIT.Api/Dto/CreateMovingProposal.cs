namespace MoveIT.Api.Dto
{
    public class CreateMovingProposal
    {
        public string AddressFrom { get; set; }

        public string AddressTo { get; set; }

        public int Distance { get; set; }

        public int LivingAreaSurface { get; set; }

        public int AtticAreaSurface { get; set; }

        public bool HasPiano { get; set; }

        public bool NeedsPackingAssistance { get; set; }
    }
}
