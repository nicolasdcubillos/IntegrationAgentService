using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace IntegrationAgentService.ProductServiceClassifier
{
    public class ProductInput
    {
        public string Description { get; set; }
        public string ServiceCode { get; set; } 
    }

    public class ProductPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedServiceCode { get; set; }
    }

}
