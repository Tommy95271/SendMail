using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SendMail
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        public Body Body { get; set; }
    }
    [XmlRoot(ElementName = "Body")]
    public class Body
    {
        [XmlElement(ElementName = "SendNowAPIResponse", Namespace = "http://tempuri.org/")]
        public MailResponseDto MailResponse { get; set; }
    }
}
