using System;

namespace MoveIT.Api.Dto
{
    public class OrderDetails : CreateOrder
    {
        public Guid? Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
