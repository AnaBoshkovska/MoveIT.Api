using System;

namespace MoveIT.Api.Dto
{
    public class MovingProposalDto : CreateMovingProposal
    {
        public Guid? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        //public string AddressFrom { get; set; }

        //public string AddressTo { get; set; }

        //public int Distance { get; set; }

        //public int LivingAreaSurface { get; set; }

        //public int AtticAreaSurface { get; set; }

        //public bool HasPiano { get; set; }

        //public bool NeedsPackingAssistance { get; set; }

        public int Price { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }
    }
}
