using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_FlightSimulator.Models
{
    //interface to handle variety of clients
    interface ClientHandler
    {
        double handleClient(string data, int index);
    }
}

