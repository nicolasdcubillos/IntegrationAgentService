using Microsoft.ML;

namespace IntegrationAgentService.ProductServiceClassifier
{
    public class TrainerML
    {
        private readonly MLContext mlContext;

        public TrainerML()
        {
            mlContext = new MLContext();
        }

        public void TrainAndSaveModel(string modelPath, List<ProductInput> trainingDataList)
        {
            var trainingData = mlContext.Data.LoadFromEnumerable(trainingDataList);

            var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(ProductInput.Description))
                .Append(mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(ProductInput.ServiceCode)))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var model = pipeline.Fit(trainingData);

            mlContext.Model.Save(model, trainingData.Schema, modelPath);

            Console.WriteLine($"Model saved to: {modelPath}");
        }
    }
}
