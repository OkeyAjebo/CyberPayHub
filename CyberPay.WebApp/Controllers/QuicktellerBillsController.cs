using CyberPay.Cmd.Payload.Quickteller;
using CyberPay.Cmd.Providers;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace CyberPay.WebApp.Controllers
{
    [RoutePrefix("api/quickteller")]
    public class QuicktellerBillsController : ApiController
    {
        private readonly IQuickTellerBillProvider billProvider;

        public QuicktellerBillsController() : this(new QuickTellerBillProvider())
        {
        }

        public QuicktellerBillsController(IQuickTellerBillProvider billProvider)
        {
            this.billProvider = billProvider;
        }

        [Route("getbillers")]
        public HttpResponseMessage GetBillers()
        {
            var billers = billProvider.GetBillers();
            ApiResult<List<QuicktellerBiller>> result = new ApiResult<List<QuicktellerBiller>>();
            return Request.CreateResponse(billers);
        }

        [Route("getbanks")]
        public HttpResponseMessage GetBankCodes()
        {
            var billers = billProvider.GetBankCodes();
            ApiResult<List<QuickTellerBank>> result = new ApiResult<List<QuickTellerBank>>();
            result.Data = billers;
            return Request.CreateResponse(result);
        }
    }
}