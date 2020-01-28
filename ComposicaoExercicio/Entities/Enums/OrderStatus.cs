using System;
using System.Collections.Generic;
using System.Text;

namespace ComposicaoExercicio.Entities.Enums
{
    enum OrderStatus : int
    {
        PendingPayment,
        Processing,
        Shipped,
        Delivered
    }
}
