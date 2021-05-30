using System;

namespace MoveIT.Core.Models
{
    public class MovingProposal
    {
        public Guid Id { get; set; }

        public string AddressFrom { get; set; }

        public string AddressTo { get; set; }

        public int Distance { get; set; }

        public int LivingAreaSurface { get; set; }

        public int AtticAreaSurface { get; set; }

        public bool HasPiano { get; set; }

        public bool NeedsPackingAssistance { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
