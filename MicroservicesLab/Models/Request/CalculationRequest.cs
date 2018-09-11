using System;

namespace MicroservicesLab.Models
{
    public class CalculationRequest
    {
        public Guid Id { get; set; }
        public string CalculationType { get; set; }
        
        public double FirstNumber { get; set; }

        public double SecondNumber { get; set; }

        public CalculationRequest()
        {
            this.Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return "CalculationType=" + 
                CalculationType.ToString() + ",FirstNumber=" + FirstNumber + ",SecondNumber" + SecondNumber;
        }
    }
}
