﻿using System;
using System.Collections.Generic;

namespace EFDemo01.ModelNWD;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
