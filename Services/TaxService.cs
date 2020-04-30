using System;
using System.Collections.Generic;
using System.Text;

namespace DublinCarRental.Services
{
    public interface ITaxService
    {
        double Tax(double amount);
    }
}
