namespace MicroservicesLab.Models
{
    using System;

    public class CalculationResponse
    {
        public Guid CalculationId { get; set; }
        public CalculationRequest CalculationRequest { get; set; }

        public double Sum { get; set; }

        public CalculationResponse(CalculationRequest request)
        {
            this.CalculationId = request.Id;
            this.CalculationRequest = request;
        }
    }
}
