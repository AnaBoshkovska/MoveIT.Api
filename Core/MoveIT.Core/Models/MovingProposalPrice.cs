namespace MoveIT.Core.Models
{
    public class MovingProposalPrice : MovingProposal
    {        
        public int Price { get; set; }

        public MovingProposalPrice(MovingProposal movingProposal)
        {
            Id = movingProposal.Id;
            AddressFrom = movingProposal.AddressFrom;
            AddressTo = movingProposal.AddressTo;
            Distance = movingProposal.Distance;
            LivingAreaSurface = movingProposal.LivingAreaSurface;
            AtticAreaSurface = movingProposal.AtticAreaSurface;
            HasPiano = movingProposal.HasPiano;
            NeedsPackingAssistance = movingProposal.NeedsPackingAssistance;
            UserId = movingProposal.UserId;
            User = movingProposal.User;
            CreateDate = movingProposal.CreateDate;
            LastUpdateDate = movingProposal.LastUpdateDate;
        }
    }
}
