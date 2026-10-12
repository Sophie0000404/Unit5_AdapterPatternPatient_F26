using System;
using System.Globalization;

namespace Unit5_AdapterPatternPatient_Blazor.InsuranceSystem
{
    public class OutNetworkAdapter : InsuranceInterface
    {
        private readonly OutNetworkPatient patient;

        public OutNetworkAdapter(string newName, int newPolicyNumber)
            : this(new OutNetworkPatient(newName, newPolicyNumber))
        {
        }

        public OutNetworkAdapter(OutNetworkPatient patient)
        {
            this.patient = patient ?? throw new ArgumentNullException(nameof(patient));
        }

        public decimal CoverageAmount(int ProcedureID, decimal ProcedureCost)
        {
            return patient.CoveragePercent(ProcedureCost) * ProcedureCost;
        }

        public string getPatientName()
        {
            return patient.getPatientName();
        }

        public string getPolicyNumber()
        {
            return patient.PolicyNumber.ToString(CultureInfo.InvariantCulture);
        }

        public bool IsCovered(string patientName, string policyNumber)
        {
            return patient.IsCovered(patientName, int.Parse(policyNumber, CultureInfo.InvariantCulture)) == "yes";
        }
    }
}
