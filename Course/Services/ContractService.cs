using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Course.Entities;

namespace Course.Services
{
    internal class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void processContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updateQuota = basicQuota + _onlinePaymentService.interest(basicQuota, i);
                double fullQuota = updateQuota + _onlinePaymentService.paymentFee(updateQuota);
                contract.addInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
