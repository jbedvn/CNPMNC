﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQLHS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    public partial class HocSinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocSinh()
        {
            this.BangDiems = new HashSet<BangDiem>();
            this.HocSinhThuocLops = new HashSet<HocSinhThuocLop>();
        }
        [DisplayName("IDHS")]
        public int IDHS { get; set; }
        [DisplayName("Mã học sinh")]
        public string MaHS { get; set; }
        [DisplayName("Họ")]
        public string Ho { get; set; }
        [DisplayName("Tên")]
        public string Ten { get; set; }
        [DisplayName("Giới tính")]
        public Nullable<bool> GioiTinh { get; set; }
        [DisplayName("Ngày sinh")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [DisplayName("Email.")]
        public string Email { get; set; }
        [DisplayName("SĐT")]
        public string Sdt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocSinhThuocLop> HocSinhThuocLops { get; set; }
    }
}
