using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SendMail
{
    [XmlRoot("SendNowAPI", Namespace = "http://tempuri.org/", IsNullable = false)]
    public class MailRequestDto
    {
        /// <summary>
        /// MHU專案類別代號(如:S0001) 必填
        /// </summary>
        [XmlElement("project_category_code")]
        public string ProjectCategoryCode { get; set; } = "";
        /// <summary>
        /// 收件者姓名 必填
        /// </summary>
        [XmlElement("toname")]
        public string ToName { get; set; } = "";
        /// <summary>
        /// 收件者Email必填
        /// </summary>
        [XmlElement("toemail")]
        public string ToEmail { get; set; } = "";
        /// <summary>
        /// 寄件者姓名必填
        /// </summary>
        [XmlElement("fromname")]
        public string FromName { get; set; } = "";
        /// <summary>
        /// 寄件者Email必填
        /// </summary>
        [XmlElement("fromemail")]
        public string FromEmail { get; set; } = "";
        /// <summary>
        /// 郵件主旨必填
        /// </summary>
        [XmlElement("subject")]
        public string Subject { get; set; } = "";
        /// <summary>
        /// 郵件內容，自組HTML字串帶入必填
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; } = "";
        /// <summary>
        /// 寄送優先順序 1：低  2：中  3：高，必填
        /// </summary>
        [XmlElement("priority")]
        public string Priority { get; set; } = "";
        /// <summary>
        /// 客戶Key值(必填不可帶空值，新增至寄送記錄result table中)
        /// </summary>
        [XmlElement("cust_key")]
        public string CustKey { get; set; } = "";
        /// <summary>
        /// 附件1檔檔名，ex.note.doc必填可帶空值
        /// </summary>
        [XmlElement("file_name1")]
        public string FileName1 { get; set; } = "";
        /// <summary>
        /// 附件1檔案(base64Binary) 必填可帶空值
        /// </summary>
        [XmlElement("attach_file_stream1")]
        public string FileContent1 { get; set; } = "";
        /// <summary>
        /// 附件2檔名必填可帶空值
        /// </summary>
        [XmlElement("file_name2")]
        public string FileName2 { get; set; } = "";
        /// <summary>
        /// 附件2檔案(base64Binary) 必填可帶空值
        /// </summary>
        [XmlElement("attach_file_stream2")]
        public string FileContent2 { get; set; } = "";
        /// <summary>
        /// 附件3檔名必填可帶空值
        /// </summary>
        [XmlElement("file_name3")]
        public string FileName3 { get; set; } = "";
        /// <summary>
        /// 附件3檔案(base64Binary) 必填可帶空值
        /// </summary>
        [XmlElement("attach_file_stream3")]
        public string FileContent3 { get; set; } = "";
        /// <summary>
        /// 附件4檔名必填可帶空值
        /// </summary>
        [XmlElement("file_name4")]
        public string FileName4 { get; set; } = "";
        /// <summary>
        /// 附件4檔案(base64Binary) 必填可帶空值
        /// </summary>
        [XmlElement("attach_file_stream4")]
        public string FileContent4 { get; set; } = "";
        /// <summary>
        /// 附件5檔名必填可帶空值
        /// </summary>
        [XmlElement("file_name5")]
        public string FileName5 { get; set; } = "";
        /// <summary>
        /// 附件5檔案(base64Binary) 必填可帶空值
        /// </summary>
        [XmlElement("attach_file_stream5")]
        public string FileContent5 { get; set; } = "";
    }
}
