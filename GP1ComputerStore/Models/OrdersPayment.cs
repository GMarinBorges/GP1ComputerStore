﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GP1ComputerStore.Models
{
    public partial class OrdersPayment
    {
        public int OrderPaymentId { get; set; }
        public int CustomerId { get; set; }
        public int ReferenceNum { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Payment ReferenceNumNavigation { get; set; }
    }
}