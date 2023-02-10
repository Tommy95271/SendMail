using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.Extensions.Logging;

namespace SendMail
{
    public class MailService
    {
        private readonly HttpClientService _httpClientService;
        private readonly ILogger<MailService> _logger;
        private readonly CfgMailService _cfgMailService;

        public MailService(
            HttpClientService httpClientService,
            ILogger<MailService> logger,
            CfgMailService cfgMailService)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _cfgMailService = cfgMailService;
        }

        public async Task<bool> SendMailAsync(MailRequestDto mailData)
        {
            var xml = CreateSoapEnvelope(mailData);

            var content = new StringContent(xml, Encoding.UTF8, "text/xml");
            var emailIp = await _cfgMailService.GetSysConfigEmailIpAsync();
            var url = Path.Combine(emailIp, "Mailhunter_app/SendNow.asmx?op=SendNowAPI");
            var result = await _httpClientService.PostData<Envelope>(url, content);
            if (result is null)
            {
                return false;
            }
            else
            {
                if (result.Body.MailResponse.SendNowAPIResult)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string CreateSoapEnvelope(MailRequestDto obj)
        {
            var xmlSerializer = new XmlSerializer(typeof(MailRequestDto));
            var stringWriter = new UTF8StringWriter();

            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                OmitXmlDeclaration = true,
            };
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = XmlWriter.Create(stringWriter, settings))
            {
                xmlSerializer.Serialize(writer, obj, namespaces);
            }

            var soapEnvelope = $@"
<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
<soap:Body>
{stringWriter}
</soap:Body>
</soap:Envelope>";

            return soapEnvelope;
        }
    }
}
