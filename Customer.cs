using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class Customer
{
    public string CustomerName { get; }
    public string CustomerAddress { get; }

    public Customer(string customerName, string customerAddress)
    {
        CustomerName = customerName;
        CustomerAddress = customerAddress;
    }
}