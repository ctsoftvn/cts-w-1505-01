using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Com.Domain.Model;
using CTS.Com.Domain.Attr;

namespace CTS.W._150501.Models.Domain.Object.Client.Main
{
    public class ItemObject
    {
        [OutputText]
        public string LocaleCd { get; set; }
        [OutputText]
        public string CategoryCd { get; set; }
        [OutputText]
        public string ItemCd { get; set; }
        [OutputText]
        public string ItemName { get; set; }
        [OutputText]
        public string Notes { get; set; }
        [OutputText]
        public string LinkName { get; set; }
        [OutputText]
        public string FileCd { get; set; }
        [OutputText]
        public string ItemImage { get; set; }

    }
}
