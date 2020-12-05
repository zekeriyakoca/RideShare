using System;
using System.Collections.Generic;
using System.Text;

namespace AdessoRideShare.Utils.Infrastructure
{
  public class BusinessException : Exception
  {
    public BusinessException(string message)
        : base(message)
    {
    }
  }
}
