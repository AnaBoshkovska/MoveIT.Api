using System;

namespace MoveIT.Core.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid MovingProposalId { get; set; }

        public MovingProposal MovingProposal { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
