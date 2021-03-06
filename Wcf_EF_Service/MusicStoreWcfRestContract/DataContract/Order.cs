﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace MusicStoreWcfRestContract
{
    /// <summary>
    /// 订单实体
    /// 2017/04/01 fhr
    /// </summary>
    [Bind(Exclude = "GenreId")]
    [DataContract(Namespace = "www.ranran.MusicStoreWcfRest")]
    public class Order
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [DataMember]
        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [DataMember]
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

        [DataMember]
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }

        [DataMember]
        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string City { get; set; }

        [DataMember]
        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        public string State { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public string Country { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string Phone { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public decimal Total { get; set; }
    }
}