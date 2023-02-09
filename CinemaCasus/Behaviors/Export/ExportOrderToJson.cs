﻿using CinemaCasus.Interfaces;
using CinemaCasus.Models;
using Newtonsoft.Json;

namespace CinemaCasus.Behaviors.Export;

public class ExportOrderToJson : IExportBehaviour
{

    public string Export(object exportObject)
    {
        // Cast the object to an Order object
        Order order = (Order) exportObject;
        
        return JsonConvert.SerializeObject(order);
    }
}