using Microsoft.ML;

namespace IntegrationAgentService.ProductServiceClassifier
{
    public class ClassifierML
    {
        private readonly MLContext mlContext;
        private PredictionEngine<ProductInput, ProductPrediction> predictionEngine;

        public ClassifierML(string modelPath)
        {
            mlContext = new MLContext();

            var loadedModel = mlContext.Model.Load(modelPath, out _);
            predictionEngine = mlContext.Model.CreatePredictionEngine<ProductInput, ProductPrediction>(loadedModel);
        }

        public string Classify(string description)
        {
            var input = new ProductInput { Description = description };
            var prediction = predictionEngine.Predict(input);
            return prediction.PredictedServiceCode;
        }
    }
}
